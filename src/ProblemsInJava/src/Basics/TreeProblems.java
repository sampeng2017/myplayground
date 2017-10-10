/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Basics;

import java.util.Stack;
import problemsinjava.DataStructures.TreeNode;

/**
 *
 * @author shepeng
 */
public final class TreeProblems {
    public static TreeNode<Integer> findLowestCommonAncestor(TreeNode<Integer> tree, TreeNode<Integer> n1, TreeNode<Integer> n2) {
        assert(tree != null);
        if (n1 == null || n2 == null)
            return null;
        
        Stack<TreeNode<Integer>> stack1 = TreeNode.DfsSearch(tree, n1.getValue());
        if (stack1 == null)
            return null;
        
        Stack<TreeNode<Integer>> stack2 = TreeNode.DfsSearch(tree, n2.getValue());
        if (stack2 == null)
            return null;
        
        TreeNode<Integer> commonAncestor = null;
        while (stack1.peek() == stack2.peek()) {
            stack1.pop();
            commonAncestor = stack2.pop();
        }
        return commonAncestor;
    }
}
