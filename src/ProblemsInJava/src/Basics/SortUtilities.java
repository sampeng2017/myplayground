package Basics;

import java.util.ArrayList;

/**
 *
 * @author shepeng
 */
public abstract class SortUtilities {

    public interface Sorter<T extends Comparable> {

        void Sort(T[] a);
    }

    public static <T extends Comparable> void insertionSort(T[] a) {
        if (a == null || a.length == 0) {
            return;
        }

        for (int i = 1; i < a.length; i++) {
            for (int j = i - 1; j >= 0 && Utilities.less(a[j + 1], a[j]); j--) {
                Utilities.exchange(a, j + 1, j);
            }
        }
    }

    public static <T extends Comparable> void mergeSort(T[] a) {
        if (a == null || a.length <= 1) {
            return;
        }
        mergeSort(a, 0, a.length - 1);
    }

    private static <T extends Comparable> void mergeSort(T[] a, int p, int q) {
        if (p >= q) {
            return;
        }
        int m = p + (q - p) / 2;
        mergeSort(a, p, m);
        mergeSort(a, m + 1, q);
        merge(a, p, m, q);
    }

    private static <T extends Comparable> void merge(T[] a, int p, int m, int q) {

        // cannot create generic array in Java, use arrayList as workaround
        ArrayList<T> tmpList1 = new ArrayList<T>();
        ArrayList<T> tmpList2 = new ArrayList<T>();
        for (int i = p; i <= m; i++) {
            tmpList1.add(a[i]);
        }

        for (int i = m + 1; i <= q; i++) {
            tmpList2.add(a[i]);
        }
        int p1 = 0;
        int p2 = 0;
        int i = 0;
        while (p1 < tmpList1.size() || p2 < tmpList2.size()) {
            if (p1 == tmpList1.size()) {
                a[p + i] = tmpList2.get(p2);
                p2++;
            } else if (p2 == tmpList2.size()) {
                a[p + i] = tmpList1.get(p1);
                p1++;
            } else {
                if (Utilities.less(tmpList1.get(p1), tmpList2.get(p2))) {
                    a[p + i] = tmpList1.get(p1);
                    p1++;
                } else {
                    a[p + i] = tmpList2.get(p2);
                    p2++;
                }
            }
            i++;
        }
    }
}
