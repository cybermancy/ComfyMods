﻿namespace BetterZeeRouter {
  public sealed class SetTargetHandler : RpcMethodHandler {
    static readonly int _playerHashCode = "Player".GetStableHashCode();

    public override bool Process(ZRoutedRpc.RoutedRPCData routedRpcData) {
      routedRpcData.m_parameters.SetPos(0);
      ZDOID targetZdoid = routedRpcData.m_parameters.ReadZDOID();
      routedRpcData.m_parameters.SetPos(0);

      if (targetZdoid == ZDOID.None
          || !ZDOMan.s_instance.m_objectsByID.TryGetValue(targetZdoid, out ZDO targetZdo)) {
        return true;
      }

      if (targetZdo.m_prefab == _playerHashCode || targetZdo.GetBool(ZDOVars.s_tamed)) {
        routedRpcData.m_parameters.Clear();
        routedRpcData.m_parameters.Write(ZDOID.None);
        routedRpcData.m_parameters.m_writer.Flush();
        routedRpcData.m_parameters.m_stream.Flush();
        routedRpcData.m_parameters.SetPos(0);

        // TODO(redseiko): temporarily needed for RouteRPC to force it to send back to the original sender.
        // Proper fix is to just provide a means of indicating this should be routed to all clients.
        routedRpcData.m_senderPeerID = ZRoutedRpc.s_instance.m_id;
      }

      return true;
    }
  }
}
