using CustomPermitWPF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface Constraint<DataType>
{
    bool Check(DataType arg);
}

public class ConstraintList<DataType> : List<Constraint<DataType>>, Constraint<DataType>
{
    public bool Check(DataType arg)
    {
        foreach (Constraint<DataType> constraint in this)
            if (!constraint.Check(arg))
                return false;
        return true;

    }
}

public class EqualityConstraint<DataType> : Constraint<DataType>
{
    private DataType val;

    public EqualityConstraint(DataType val)
    {
        this.val = val;
    }

    public bool Check(DataType arg)
    {
        return arg.Equals(this.val);
    }
}

public class InclusionConstraint<DataType> : Constraint<DataType>
{
    private ICollection<DataType> options;

    public InclusionConstraint(ICollection<DataType> options)
    {
        this.options = options;
    }

    public bool Check(DataType arg)
    {
        return options.Contains(arg);
    }
}

public class RangeConstraint<DataType> : Constraint<DataType> where DataType : IComparable<DataType>
{
    private DataType from, to;

    public RangeConstraint(DataType from, DataType to)
    {
        this.from = from;
        this.to = to;
    }

    public bool Check(DataType arg)
    {
        return from.CompareTo(arg) <= 0 && to.CompareTo(arg) >= 0;
    }
}

namespace CustomPermitWPF.Domain
{
    [Table("Rules")]
    public class Rule : IdentifiedEntity, Constraint<Decleration>
    {
        public virtual ICollection<Permission_Rule> PermissionRules { get; set; }
         
        public ConstraintList<string> CommodityNameConstraints { get; set; } = new ConstraintList<string>();
        public ConstraintList<string> CountryOriginConstraints { get; set; } = new ConstraintList<string>();
        public ConstraintList<DateTime> RecordDateTimeConstraints { get; set; } = new ConstraintList<DateTime>();
        public ConstraintList<int> AmountConstraints { get; set; } = new ConstraintList<int>();

        public bool Check(Decleration doc)
        {
            if (!CommodityNameConstraints.Check(doc.CommodityName)) return false;
            if (!CountryOriginConstraints.Check(doc.CountryOrigin)) return false;
            if (!RecordDateTimeConstraints.Check(doc.RecordDateTime)) return false;
            if (!AmountConstraints.Check(doc.Amount)) return false;
            return true;
        }
    }

    public class Rules : List<Rule>
    {
        public List<Rule> FindConflictingRules(Decleration doc)
        {
            List<Rule> conflictingRules = new List<Rule>();
            foreach (Rule rule in this)
                if (!rule.Check(doc))
                    conflictingRules.Add(rule);
            return conflictingRules;
        }
    }
}
