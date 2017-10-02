/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import Basics.LinkedListProblems;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;
import problemsinjava.DataStructures.LinkedListNode;

/**
 *
 * @author shepeng
 */
public class BasicsTests {
    
//    public BasicsTests() {
//    }
//    
//    @BeforeClass
//    public static void setUpClass() {
//    }
//    
//    @AfterClass
//    public static void tearDownClass() {
//    }
//    
//    @Before
//    public void setUp() {
//    }
//    
//    @After
//    public void tearDown() {
//    }

    // TODO add test methods here.
    // The methods must be annotated with annotation @Test. For example:
    //
    @Test
    public void linkedList_reverse() {
        LinkedListNode<Integer> l = new LinkedListNode<> ();
        l.setValue(1);
        
        LinkedListNode<Integer> l2 = new LinkedListNode<> ();
        l2.setValue(2);

        LinkedListNode<Integer> l3 = new LinkedListNode<> ();
        l3.setValue(3);
        l.setNext(l2);
        l2.setNext(l3);
        
        LinkedListNode<Integer> r = LinkedListProblems.reverse(l);
        assertEquals(3, (int)r.getValue());

        LinkedListNode<Integer> r2 = r.getNext();
        assertEquals(2, (int)r2.getValue());

        LinkedListNode<Integer> r3 = r2.getNext();
        assertEquals(1, (int)r3.getValue());
    }
}
