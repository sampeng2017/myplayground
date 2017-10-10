/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Basics;

import problemsinjava.DataStructures.LinkedListNode;

/**
 *
 * @author shepeng
 */
public final class LinkedListProblems {

    public static <T> LinkedListNode<T> reverse(LinkedListNode<T> list) {
        return reverse(list, null);
    }

    private static <T> LinkedListNode<T> reverse(LinkedListNode<T> list, LinkedListNode<T> previous) {
        if (list == null) {
            return previous;
        }
        LinkedListNode<T> tmp = list.getNext();
        list.setNext(previous);
        return reverse(tmp, list);
    }
}
