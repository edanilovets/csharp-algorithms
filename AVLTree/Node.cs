namespace AVLTree
{
    class Node
    {
        public Node leftChild;
        public Node rightChild;
        public int data;
        public int balance;

        public Node(int data)
        {
            this.data = data;
            this.balance = 0;
            this.leftChild = null;
            this.rightChild = null;
        }

        public Node Search(int value)
        {
            if (value == data)
            {
                return this;
            }

            if (value < data)
            {
                if (leftChild != null)
                {
                    return leftChild.Search(value);
                }
            }
            else
            {
                if (rightChild != null)
                {
                    return rightChild.Search(value);
                }
            }
            return null;
        }
    }
}
