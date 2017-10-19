/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import Others.GeekForGeeks;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author shepeng
 */
public class GeekForGeekTests {

    @Test
    public void maxIndexDiff() {
      int[] a = {3, 5, 4, 2};
      int[] r = GeekForGeeks.maxIndexDiff(a);
      
      // for index pair 0, 2
      int[] expected = {2, 0, 2};
      assertArrayEquals(expected, r);
      
      int[] a2 = {34, 8, 10, 3, 2, 80, 30, 33, 1};
      r = GeekForGeeks.maxIndexDiff(a2);
        // for index pair 0, 2
      int[] expected2 = {6, 1, 7};
      assertArrayEquals(expected2, r);
    }

}
