﻿using System.Collections.Generic;

namespace EnRoute {
  public class RouteRecord {
    public readonly ZNetPeer NetPeer;
    public readonly long UserId;
    public readonly HashSet<long> NearbyUserIds = new();

    public Vector2i Sector { get; private set; }

    public RouteRecord(ZNetPeer netPeer) {
      NetPeer = netPeer;
      UserId = netPeer.m_uid;
    }

    public void UpdateRecord() {
      Sector = ZoneSystem.instance.GetZone(NetPeer.m_refPos);
    }
  }
} 
