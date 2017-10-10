package problemsinjava.DataStructures;

import java.util.Stack;

/**
 *
 * @author shepeng
 */
public class TreeNode<T> {

    private T value;
    private TreeNode<T> left;
    private TreeNode<T> right;

    public T getValue() {
        return value;
    }

    public TreeNode<T> getLeft() {
        return left;
    }

    public TreeNode<T> getRight() {
        return right;
    }

    public void setValue(T value) {
        this.value = value;
    }

    public void setLeft(TreeNode<T> left) {
        this.left = left;
    }

    public void setRight(TreeNode<T> right) {
        this.right = right;
    }

    public static <T1 extends Comparable<T1>> Stack<TreeNode<T1>> DfsSearch(TreeNode<T1> tree, T1 val) {
        assert (val != null);
        if (tree == null) {
            return null;
        }
        Stack<TreeNode<T1>> stack = null;
        if (val.compareTo(tree.getValue()) == 0) {
            stack = new Stack<>();
            stack.add(tree);
            return stack;
        }

        stack = DfsSearch(tree.getLeft(), val);
        if (stack != null) {
            stack.add(tree);
            return stack;
        }

        stack = DfsSearch(tree.getRight(), val);
        if (stack != null) {
            stack.add(tree);
            return stack;
        }

        return null;
    }
}
