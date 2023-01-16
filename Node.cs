using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Node
    {
        public int value;
        public Node left, right;

        public Node(int item) {
            value = item;
            left = right = null;
        }
    }

    public class Forest {
        private Node root;

        public Forest() {
            root = null;
        }

        public void insert(int key) {
            root = insertRec(root,key);
        }

        private Node insertRec(Node root,int key) {
            if (root == null) {
                root = new Node(key);
                return root;
            }

            if (key < root.value)
                root.left = insertRec(root.left, key);
            else if (key > root.value)
                root.right = insertRec(root.right, key);

            return root;
        }

        public void output() {
            outputRec(root);
        }

        private void outputRec(Node root) {
            if (root != null) {
                outputRec(root.left);
                Console.Write(root.value + " ");
                outputRec(root.right);
            }
        }

        public void deleteValue(int value) {
            root = deleteRec(root, value);
        }

        private int minValue(Node root) {
            int minValue = root.value;

            while (root.left != null) {
                minValue = root.left.value;
                root = root.left;
            }

            return minValue;
        }

        private Node deleteRec(Node root, int value) {
            if (root == null)
                return root;

            if (value < root.value)
                root.left = deleteRec(root.left, value);
            else if (value > root.value)
                root.right = deleteRec(root.right, value);
            else {
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;

                root.value = minValue(root.right);

                //Found it. Replace root. 
                root.right = deleteRec(root.right,root.value);
            }

            return root;
        }
    }
}
