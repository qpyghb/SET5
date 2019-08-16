using ETModel;

namespace ETHotfix
{
	[Config((int)(AppType.ClientH))]
	public partial class HumanConfigCategory : ACategory<HumanConfig>
	{

	}

	public class HumanConfig: IConfig
	{
		public long Id { get; set; }
		public string Name;
		public string Desc;
		public int Position;
		public int Height;
		public int Weight;
	}
}
