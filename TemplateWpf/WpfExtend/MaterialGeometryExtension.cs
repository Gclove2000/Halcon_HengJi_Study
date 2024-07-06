using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media;

namespace TemplateWpf.WpfExtend
{
    public class MaterialGeometryExtension : PackIconGeometryExtension<PackIconMaterialKind>
    {
        protected override IDictionary<PackIconMaterialKind, string> DataIndex => PackIconMaterialDataFactory.DataIndex.Value;

        public MaterialGeometryExtension()
        {
        }

        public MaterialGeometryExtension(PackIconMaterialKind kind) : base(kind) { }
    }

    public abstract class PackIconGeometryExtension<TKind> : MarkupExtension where TKind : Enum
    {
        public TKind Kind { get; set; }

        protected abstract IDictionary<TKind, string> DataIndex { get; }

        protected PackIconGeometryExtension() { }

        protected PackIconGeometryExtension(TKind kind) => Kind = kind;

        public override object ProvideValue(IServiceProvider serviceProvider) => Geometry.Parse(DataIndex[Kind]);
    }


}
