namespace UseCollectionViewLinkSL {
    public class MonthItem {
        public string Name { get; private set; }
        public int Quarter { get; private set; }

        public MonthItem(string name, int quarter) {
            Name = name;
            Quarter = quarter;
        }
    }
}
