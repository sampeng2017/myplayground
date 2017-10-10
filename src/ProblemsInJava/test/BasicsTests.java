/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import Basics.ArrayProblems;
import Basics.LinkedListProblems;
import Basics.TreeProblems;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;
import problemsinjava.DataStructures.LinkedListNode;
import problemsinjava.DataStructures.TreeNode;

/**
 *
 * @author shepeng
 */
public class BasicsTests {

    @Test
    public void linkedList_reverse() {
        LinkedListNode<Integer> l = new LinkedListNode<>();
        l.setValue(1);
        LinkedListNode<Integer> l2 = new LinkedListNode<>();
        l2.setValue(2);
        LinkedListNode<Integer> l3 = new LinkedListNode<>();
        l3.setValue(3);

        l.setNext(l2);
        l2.setNext(l3);

        LinkedListNode<Integer> r = LinkedListProblems.reverse(l);
        assertEquals(3, (int) r.getValue());

        LinkedListNode<Integer> r2 = r.getNext();
        assertEquals(2, (int) r2.getValue());

        LinkedListNode<Integer> r3 = r2.getNext();
        assertEquals(1, (int) r3.getValue());
    }

    @Test
    public void array_findMinAndMax() {
        int a[] = {4, 32, 2, 27, 15};
        int r[] = ArrayProblems.findMinAndMax(a);
        assertEquals(2, r[0]);
        assertEquals(32, r[1]);
    }

    @Test
    public void tree_findLowestCommonAncestor() {
        TreeNode<Integer> t1 = new TreeNode<>();
        t1.setValue(1);
        TreeNode<Integer> t2 = new TreeNode<>();
        t2.setValue(2);
        TreeNode<Integer> t3 = new TreeNode<>();
        t3.setValue(3);
        TreeNode<Integer> t4 = new TreeNode<>();
        t4.setValue(4);
        TreeNode<Integer> t5 = new TreeNode<>();
        t5.setValue(5);
        TreeNode<Integer> t6 = new TreeNode<>();
        t6.setValue(6);
        TreeNode<Integer> t7 = new TreeNode<>();
        t7.setValue(7);
        TreeNode<Integer> t8 = new TreeNode<>();
        t8.setValue(8);

        t1.setLeft(t2);
        t1.setRight(t3);
        t2.setLeft(t4);
        t2.setRight(t5);
        t3.setLeft(t6);
        t3.setRight(t7);
        t7.setRight(t8);

        TreeNode<Integer> r = TreeProblems.findLowestCommonAncestor(t1, t6, t8);
        assertEquals(t3, r);
    }
}
