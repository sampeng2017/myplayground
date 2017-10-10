package Others;

/**
 *
 * @author shepeng
 */
public class OldProblems {

    public static int[] findInSorted2DArray(int[][] ary, int val) {
        if (ary == null || ary.length == 0) {
            return null;
        }

        int h = ary.length;
        int w = ary[0].length;
        if (w == 0) {
            return null;
        }

        int[] result = new int[2];
        int i = h - 1;
        int j = 0;
        while (i >= 0 && j < w) {
            int key = ary[i][j];
            if (key == val) {
                result[0] = i;
                result[1] = j;
                return result;
            }
            if (key > val) {
                i--;
            } else {
                j++;
            }
        }
        return null;
    }
}
