/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Others;

import java.util.*;
import javafx.util.Pair;

/**
 *
 * @author shepeng
 */
public class BuildResolver {

    public static Iterable<String> GetBuildOrder(Iterable<Pair<String, Iterable<String>>> moduleAndDependencies) throws Exception {

        if (moduleAndDependencies == null) {
            return null; // or throw
        }
        Map<String, ModuleNode> modules = buildModuleNodes(moduleAndDependencies);

        ArrayList<ModuleNode> allModules = new ArrayList<ModuleNode>(modules.values());
        ArrayList<String> result = new ArrayList<String>();

        while (!allModules.isEmpty()) {
            ModuleNode module = allModules.get(0); //can start from any item
            Iterable<ModuleNode> sorted = topologicalSort(module);
            for (ModuleNode m : sorted) {
                allModules.remove(m);
                result.add(m.getName());
            }
        }

        return result;
    }

    private static Map<String, ModuleNode> buildModuleNodes(Iterable<Pair<String, Iterable<String>>> moduleAndDependencies) {

        HashMap<String, ModuleNode> nodeMap = new HashMap<String, ModuleNode>();

        for (Pair<String, Iterable<String>> pair : moduleAndDependencies) {
            ModuleNode node = getOrAddModuleNode(pair.getKey(), nodeMap);
            for (String dependency : pair.getValue()) {
                ModuleNode dNode = getOrAddModuleNode(dependency, nodeMap);
                node.AddDependency(dNode);
            }
        }

        return nodeMap;
    }

    private static ModuleNode getOrAddModuleNode(String moduleName, Map<String, ModuleNode> map) {
        ModuleNode node = null;
        if (map.containsKey(moduleName)) {
            node = map.get(moduleName);
        } else {
            node = new ModuleNode(moduleName);
            map.put(moduleName, node);
        }
        return node;
    }

    private static Iterable<ModuleNode> topologicalSort(ModuleNode m) throws Exception {
        Stack<ModuleNode> sortStack = new Stack<ModuleNode>();
        topologicalSort(m, sortStack, new HashSet<ModuleNode>(), new Stack<ModuleNode>());

        List<ModuleNode> result = new ArrayList<ModuleNode>();
        while (!sortStack.isEmpty()) {
            result.add(sortStack.pop());
        }
        return result;
    }

    private static void topologicalSort(ModuleNode m, Stack<ModuleNode> sortStack, HashSet<ModuleNode> visited, Stack<ModuleNode> recursionStack) throws Exception {

        if (recursionStack.contains(m)) {
            throw new Exception("Circular path detected: " + recursionStack.peek().getName() + " -> " + m.getName());
        }
        if (visited.contains(m)) {
            return;
        }

        recursionStack.push(m);
        sortStack.push(m);
        visited.add(m);
        for (ModuleNode d : m.getDependencies()) {
            topologicalSort(d, sortStack, visited, recursionStack);
        }
        recursionStack.pop();
    }
}

class ModuleNode {

    private final String name;
    private final ArrayList<ModuleNode> dependencies;

    public ModuleNode(String name) {
        this.name = name;
        this.dependencies = new ArrayList<ModuleNode>();
    }

    public String getName() {
        return name;
    }

    public Iterable<ModuleNode> getDependencies() {
        return dependencies;
    }

    public void AddDependency(ModuleNode m) {
        this.dependencies.add(m);
    }
}
