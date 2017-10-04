/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import Others.BuildResolver;
import java.util.*;
import static java.util.Arrays.asList;
import javafx.util.Pair;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author shepeng
 */
public class OthersTests {

    @Test
    public void BuildOrderTest() throws Exception {

        Iterable<String> buildOrder = null;
        List<String> list = new ArrayList<String>();

        // null input
        buildOrder = BuildResolver.GetBuildOrder(null);
        assertEquals(null, buildOrder);

        // single module
        ArrayList<Pair<String, Iterable<String>>> moduleWithDependencies = new ArrayList<Pair<String, Iterable<String>>>();
        Pair<String, Iterable<String>> c = new Pair<String, Iterable<String>>("c", new ArrayList<String>());
        moduleWithDependencies.add(c);

        buildOrder = BuildResolver.GetBuildOrder(moduleWithDependencies);
        buildOrder.forEach(list::add);
        assertArrayEquals(list.toArray(), new String[]{"c"});
        list.clear();

        // multiple modules
        // a -> b, c
        // b -> c, d
        // d -> e
        // f -> g
        Pair<String, Iterable<String>> f = new Pair<String, Iterable<String>>("f", new ArrayList<String>(asList("g")));
        Pair<String, Iterable<String>> a = new Pair<String, Iterable<String>>("a", new ArrayList<String>(asList("b", "c")));
        Pair<String, Iterable<String>> b = new Pair<String, Iterable<String>>("b", new ArrayList<String>(asList("c", "d")));
        Pair<String, Iterable<String>> d = new Pair<String, Iterable<String>>("d", new ArrayList<String>(asList("e")));
        moduleWithDependencies.add(f);
        moduleWithDependencies.add(a);
        moduleWithDependencies.add(b);
        moduleWithDependencies.add(d);

        buildOrder = BuildResolver.GetBuildOrder(moduleWithDependencies);
        buildOrder.forEach(list::add);

        assertArrayEquals(list.toArray(), new String[]{"e", "d", "c", "b", "a", "g", "f"});
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
}
