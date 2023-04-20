using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGatheredGoldenBall : CoinGathered
{
    public override int GatherCoin(int value)
    {
        return value * 2;
    }
}
