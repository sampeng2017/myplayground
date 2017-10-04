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
    public void BuildOrderTest() {
        // a -> b, c
        // b -> c, d
        // d -> e
        // f -> g
        ArrayList<Pair<String, Iterable<String>>> moduleWithDependencies = new ArrayList<Pair<String, Iterable<String>>>();
        Pair<String, Iterable<String>> c = new Pair<String, Iterable<String>>("c", new ArrayList<String>());
        Pair<String, Iterable<String>> f = new Pair<String, Iterable<String>>("f", new ArrayList<String>(asList("g")));
        Pair<String, Iterable<String>> a = new Pair<String, Iterable<String>>("a", new ArrayList<String>(asList("b", "c")));
        Pair<String, Iterable<String>> b = new Pair<String, Iterable<String>>("b", new ArrayList<String>(asList("c", "d")));
        Pair<String, Iterable<String>> d = new Pair<String, Iterable<String>>("d", new ArrayList<String>(asList("e")));
        moduleWithDependencies.add(c);
        moduleWithDependencies.add(f);
        moduleWithDependencies.add(a);
        moduleWithDependencies.add(b);
        moduleWithDependencies.add(d);

        Iterable<String> buildOrder = null;
        try {

            buildOrder = BuildResolver.GetBuildOrder(moduleWithDependencies);
        }
        catch (Exception ex) {
            fail("unexpected");
        }
        List<String> list = new ArrayList<String>();
        buildOrder.forEach(list::add);
            
        org.junit.Assert.assertArrayEquals(list.toArray(), new String[] {"e", "d", "c", "b", "a", "g", "f"});
        
        // circular dependecy scenario. e -> b
        moduleWithDependencies.add(new Pair<String, Iterable<String>>("e", new ArrayList<String>(asList("b"))));
         try {
            buildOrder = BuildResolver.GetBuildOrder(moduleWithDependencies);
            fail("expected exception not raised");
        }
        catch (Exception ex) {
            org.junit.Assert.assertEquals(ex.getMessage(), "Circular path detected: e -> b");
        }
    }
}
