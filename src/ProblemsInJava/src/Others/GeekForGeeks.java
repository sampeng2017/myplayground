/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Others;

/**
 *
 * @author shepeng
 */
public class GeekForGeeks {

    public static int[] maxIndexDiff(int arr[]) {
        int n = arr.length;

        int i = 0, j = 0;

        /* Construct LMin[] such that LMin[i] stores the minimum value
           from (arr[0], arr[1], ... arr[i]) */
        int[] lMin = new int[n];
        lMin[0] = arr[0];
        for (i = 1; i < n; i++) {
            lMin[i] = Math.min(arr[i], lMin[i - 1]);
        }
        /* Construct RMax[] such that RMax[j] stores the maximum value
           from (arr[j], arr[j+1], ..arr[n-1]) */
        int[] rMax = new int[n];
        rMax[n - 1] = arr[n - 1];
        for (j = n - 2; j >= 0; j--) {
            rMax[j] = Math.max(arr[j], rMax[j + 1]);
        }

        /* Traverse both arrays from left to right to find optimum j - i
           This process is similar to merge() of MergeSort */
        i = 0;
        j = 0;
        int ri = 0;
        int rj = 0;
        int maxDiff = -1;
        while (j < n && i < n) {
            if (lMin[i] < rMax[j]) {
                if (maxDiff < j - i) {
                    ri = i;
                    rj = j;
                    maxDiff = j - i;
                }
                j++;
            } else {
                i++;
            }

        }

        int[] result = new int[3];
        result[0] = maxDiff;
        result[1] = ri;
        result[2] = rj;
        return result;
    }
}
