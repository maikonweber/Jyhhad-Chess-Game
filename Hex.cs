using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hex {
    public Hex (int q, int r)
    {
        this.Q = q;
        this.R = r;
        this.S = -(q + r);
    }

    public readonly int Q;
    public readonly  int R;
    public readonly int S;

    bool AllowWrapEastWest = true;
    bool AllowWrapNortSouth = false;

    public float Elavation;
    public float Moisture;

    float radius = 1f;

    public readonly HexGenerate hexGenerate;

    static readonly float WIDTH_MULTIPLIER = Mathf.Sqrt(3) / 2;

    public Vector3 Position() 
    {
        return new Vector3 (
        HexHorizontalSpacing() * (this.Q + this.R/2f), 0, HexVerticalSpacing() 
        * this.R
        );
    }

    public float HexHeight()
    {
        return radius * 2;
    }


    public float HexWidth() {
        return WIDTH_MULTIPLIER * HexHeight();
    }

    public float HexVerticalSpacing() {
        return HexHeight() * 0.75f;
    }

    public float HexHorizontalSpacing() 
    {
        return  HexWidth();
    }


}