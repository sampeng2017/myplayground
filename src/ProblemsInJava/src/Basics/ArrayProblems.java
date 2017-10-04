/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Basics;

/**
 *
 * @author shepeng
 */
public class ArrayProblems {
    public static int[] findMinAndMax(int[] a) {
        if (a == null || a.length == 0)
            return a;
        int[] r = new int[2];
        if (a.length == 1) {
            r[0] = r[1] = a[0];
            return r;
        }
        
        int min = Integer.MAX_VALUE;
        int max = Integer.MIN_VALUE;
        for (int i = 0; i < a.length; i++) {
            int k = a[i];
            if (k > max)
                max = k;
            if (k < min)
                min = k;
        }
        r[0] = min;
        r[1] = max;
        return r;
    }
            
}
