using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TslAnalyzer
{
    public static class Types
    {
        public static List<string> Type = new List<string>()
        {
            "int", "double", "char", "String", "Point3d", "Vector3d", "Line", "Plane", "LineBeamIntersect", "MetalPart", "PLine",  "HardWrComp", "View", "Block", "Cut", "Drill", "BeamCut", "Slot", "Mortise", "House", "Dove", "Mark", "HousedDove", "RoundWoodMill", "DoubleCut", "PropInt", "PropDouble", "PropString", "DimLine", "Dim", "Arc", "ParHouse", "PrPoint", "PrEntity", "CoordSys", "ElemZone", "ElemNail", "ElemNoNail", "ElemSaw", "ElemMill", "ElemDrill", "ElemMarker", "Rabbet", "Daddo", "FreeProfile", "Display", "SolidSubtract", "Body", "Viewport", "ViewData", "EntityCollection", "ChamferedLap", "SpecialMill", "RevolutionMill", "CncMessage", "Entity", "ToolEnt", "GenBeam", "Beam", "Sip", "Sheet", "Element", "TslInst", "Opening", "OpeningSF", "Wall", "Slab", "ShopDrawView", "MasterPanel", "ChildPanel", "CollectionEntity", "TrussEntity", "MetalPartCollectionEnt", "MvBlockRef", "ElementWall", "ElementLog", "DimTool", "Map", "ModelMap", "ModelMapComposeSettings", "ModelMapInterpretSettings", "CncExport", "DiagonalNotch", "ElemItem", "MetalTKey", "ElemConstructionBeam", "ElemConstructionMap", "NailLine", "PlaneProfile", "LineSeg", "ERoofPlane", "Chamfer", "ScarfJoint", "HalfCut", "PanelStop", "ElemText", "ElementWallSF", "EntPLine", "Group", "ElementRoof", "ElemRoofEdge", "OpeningRoof", "OpeningLog", "MarkerLine", "LogNotch", "TirolerSchloss", "Grid", "DictObject", "ExtrProfile", "CurvedStyle", "ComplexProfile", "ERoofPlaneOpening", "ExtrProfileCut", "SipComponent", "SipStyle", "SipEdge", "LogCourse", "Hatch", "PanelSplit", "ElemNailCluster", "ElementMulti", "SingleElementRef", "MasterPanelStyle", "CollectionDefinition", "TrussDefinition", "MetalPartCollectionDef", "MvBlockDef", "MapObject", "Quader", "DimRequest", "AnalysedTool", "AnalysedCut", "AnalysedBeamCut", "AnalysedDoubleCut", "AnalysedDrill", "AnalysedHouse", "AnalysedMortise", "AnalysedSlot", "AnalysedDove", "AnalysedSpecialMill", "AnalysedConvexConcaveProfile", "AnalysedComplexProfile", "AnalysedLogNotch", "AnalysedDiagonalNotch", "AnalysedShoulderTenon", "AnalysedParHouse", "AnalysedMarker", "AnalysedFreeProfile", "AnalysedChamferedLap", "AnalysedKamatsugi", "AnalysedDovesugi", "AnalysedAri", "AnalysedSimpleScarf", "AnalysedScarfJoint", "AnalysedArc", "AnalysedRabbet", "AnalysedLogDove", "AnalysedChamfer", "AnalysedPlaning", "NesterChild", "NesterMaster", "NesterData", "NesterCaller", "DimRequestLinear", "DimRequestPoint", "DimRequestAngular", "DimRequestText", "DimRequestPitch", "DimRequestObholz", "DimRequestHeightLevel", "DimRequestMultiViewLine", "DimRequestRadial", "DimRequestPLine", "DimRequestChain", "DimRequestHatch"
        };

        public static bool IsKeyword(this string st)
        {
            return Type.IndexOf(st) >= 0;
        }
    }
}
