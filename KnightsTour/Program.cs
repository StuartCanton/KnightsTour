using KnightsTour;
using KnightsTour.Data;


//KnightsTour_fromShad KTs = new(6);
//KTs.FindKT(0,0);

KnightsTour_1_Closed KT1 = new(6);
KT1.FindKT();

CityBackTrack cityBackTrack = new();
cityBackTrack.FindTour();

//KnightsTour_2_Closed KT2 = new(8, 0, 0);
//KT2.FindKT();
//KT2.FindQuadPath();

//MinimumSpanningTree2 MST2 = new();

//KT2.TestLandingSquare();
//KT2.PrintMoves();

