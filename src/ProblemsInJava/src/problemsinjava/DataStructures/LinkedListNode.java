/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package problemsinjava.DataStructures;

/**
 *
 * @author shepeng
 */
public class LinkedListNode<T> {
    private T value;
    private LinkedListNode<T> next;
    
    public T getValue() {
        return this.value;
    }
    
    public void setValue(T val) {
        this.value = val;
    }
    
    public LinkedListNode<T> getNext() {
        return this.next;
    }
            
    public void setNext(LinkedListNode<T> n) {
        this.next = n;
    }
}
