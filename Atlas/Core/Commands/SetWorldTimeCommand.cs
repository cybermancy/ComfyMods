﻿using System;

namespace Atlas {
  public static class SetWorldTimeCommand {
    public static Terminal.ConsoleCommand Register() {
      return new Terminal.ConsoleCommand(
          "setworldtime",
          "setworldtime <time>",
          args => Run(args));
    }

    public static bool Run(Terminal.ConsoleEventArgs args) {
      if (args.Length < 2 || !double.TryParse(args[1], out double time) || time < 0f) {
        PluginLogger.LogError($"setworldtime: invalid or missing <time> argument.");
        return false;
      }

      double netTime = ZNet.m_instance.m_netTime;
      long offsetTicks = (long) ((time - netTime) * TimeSpan.TicksPerSecond);

      long timeTicks = (long) time * TimeSpan.TicksPerSecond;
      long nowTicks = DateTimeOffset.Now.ToUnixTimeSeconds() * TimeSpan.TicksPerSecond;

      PluginLogger.LogInfo($"Setting ZNet.m_netTime from {netTime} to {time}.");
      PluginLogger.LogInfo($"Offsetting all world ZDO.timeCreated values by {offsetTicks} ticks.");

      long zdosOffset = 0L;
      long zdosSetToEpoch = 0L;

      ZNet.m_instance.m_netTime = time;

      foreach (ZDO zdo in ZDOMan.s_instance.m_objectsByID.Values) {
        if (ZDOExtraData.GetLong(zdo.m_uid, Atlas.EpochTimeCreatedHashCode, out long epochTimeCreated)) {
          long timeCreated = (epochTimeCreated * TimeSpan.TicksPerSecond) - nowTicks + timeTicks;

          ZDOExtraData.s_tempTimeCreated[zdo.m_uid] = timeCreated;
          zdo.Set(Atlas.TimeCreatedHashCode, timeCreated);

          zdosSetToEpoch++;
        } else if (TryGetTimeCreated(zdo, out long timeCreated) && timeCreated != 0L) {
          timeCreated += offsetTicks;

          ZDOExtraData.s_tempTimeCreated[zdo.m_uid] = timeCreated;
          zdo.Set(Atlas.TimeCreatedHashCode, timeCreated);

          zdosOffset++;
        }
      }

      PluginLogger.LogInfo($"Finished! zdosSetToEpoch: {zdosSetToEpoch}, zdosOffset: {zdosOffset}.");
      return true;
    }

    static bool TryGetTimeCreated(ZDO zdo, out long timeCreated) {
      if (ZDOExtraData.s_longs.TryGetValue(zdo.m_uid, out BinarySearchDictionary<int, long> values)
          && values.TryGetValue(Atlas.TimeCreatedHashCode, out timeCreated)) {
        return true;
      } else if (ZDOExtraData.s_tempTimeCreated.TryGetValue(zdo.m_uid, out timeCreated)) {
        return true;
      }

      timeCreated = default;
      return false;
    }
  }
}
