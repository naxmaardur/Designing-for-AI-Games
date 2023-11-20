using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;


[Category("✫ Custom")]
public class CheckHouseActorCount : ConditionTask
{

    public BBParameter<House> valueA;
    public CompareMethod checkType = CompareMethod.EqualTo;
    public BBParameter<int> valueB;

    [SliderField(0, 0.1f)]
    public float differenceThreshold = 0.05f;

    protected override string info
    {
        get { return valueA + OperationTools.GetCompareString(checkType) + valueB; }
    }

    protected override bool OnCheck()
    {
        return OperationTools.Compare(valueA.value.GetActorsCount(), valueB.value, checkType, differenceThreshold);
    }
}