package Basics;

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
}
