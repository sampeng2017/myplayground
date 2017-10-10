
import Others.BuildResolver;
import Others.OldProblems;
import java.util.*;
import static java.util.Arrays.asList;
import javafx.util.Pair;
import org.junit.Test;
import static org.junit.Assert.*;

public class OthersTests {

    @Test
    public void buildOrderTest() throws Exception {

        Iterable<String> buildOrder = null;
        List<String> list = new ArrayList<String>();

        // null input
        buildOrder = BuildResolver.GetBuildOrder(null);
        assertEquals(null, buildOrder);

        // multiple modules
        // a -> {b, c}
        // b -> {c, d, g}
        // d -> {e}
        // f -> {g}
        // c -> {}
        Pair<String, Iterable<String>> f = new Pair<String, Iterable<String>>("f", new ArrayList<String>(asList("g")));
        Pair<String, Iterable<String>> a = new Pair<String, Iterable<String>>("a", new ArrayList<String>(asList("b", "c")));
        Pair<String, Iterable<String>> b = new Pair<String, Iterable<String>>("b", new ArrayList<String>(asList("c", "d", "g")));
        Pair<String, Iterable<String>> d = new Pair<String, Iterable<String>>("d", new ArrayList<String>(asList("e")));
        Pair<String, Iterable<String>> c = new Pair<String, Iterable<String>>("c", new ArrayList<String>());
        ArrayList<Pair<String, Iterable<String>>> moduleWithDependencies = new ArrayList<Pair<String, Iterable<String>>>();
        moduleWithDependencies.add(c);
        moduleWithDependencies.add(f);
        moduleWithDependencies.add(a);
        moduleWithDependencies.add(b);
        moduleWithDependencies.add(d);

        buildOrder = BuildResolver.GetBuildOrder(moduleWithDependencies);
        buildOrder.forEach(list::add);

        assertArrayEquals(list.toArray(), new String[]{"g", "e", "d", "c", "b", "a", "f"});
        list.clear();

        // circular dependecy e -> b
        moduleWithDependencies.add(new Pair<String, Iterable<String>>("e", new ArrayList<String>(asList("b"))));
        try {
            buildOrder = BuildResolver.GetBuildOrder(moduleWithDependencies);
            fail("expected exception not raised");
        } catch (Exception ex) {
            assertEquals(ex.getMessage(), "Circular path detected: e -> b");
        }
    }

    @Test
    public void findInSorted2DArrayTest() {
        int[][] sorted2dArray = {
            {1, 2, 4, 5, 6},
            {3, 7, 8, 9, 11},
            {13, 15, 16, 20, 28},
            {14, 17, 18, 21, 32}
        };
        int[] r = OldProblems.findInSorted2DArray(sorted2dArray, 9);
        assertEquals(1, r[0]);
        assertEquals(3, r[1]);

        r = OldProblems.findInSorted2DArray(sorted2dArray, 10);
        assertEquals(null, r);
    }
}
