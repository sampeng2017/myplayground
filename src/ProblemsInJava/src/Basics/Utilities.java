/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Basics;

import java.util.Random;

/**
 *
 * @author shepeng
 */
public abstract class Utilities {

    public static <T> void exchange(T[] a, int i, int j) {
        assert (a != null);
        assert (i >= 0 && i < a.length);
        assert (j >= 0 && j < a.length);

        if (i != j) {
            T tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }
    }

    public static <T extends Comparable> boolean less(T i, T j) {
        return i.compareTo(j) < 0;
    }

    public static boolean isSorted(Integer[] a) {
        int previous = Integer.MIN_VALUE;
        for (int i = 0; i < a.length; i++) {
            if (a[i] < previous) {
                return false;
            }
            previous = a[i];
        }
        return true;
    }

    // todo: how to easily convert int[] to Integer[] ?
    public static Integer[] getRandomArray(int cnt) {
        Integer[] ary = new Integer[cnt];
        Random rand = new Random();
        for (int i = 0; i < cnt; i++) {
            ary[i] = rand.nextInt();
        }
        return ary;
    }
}
