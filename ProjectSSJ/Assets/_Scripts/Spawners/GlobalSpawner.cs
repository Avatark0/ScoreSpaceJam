using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalSpawner {
    private static int bug_index;
    private static Event[] bug_spawns;
    private static int platform_index;
    private static Event[] platform_spawns;
    private static int drop_index;
    private static Event[] drop_spawns;
    private class Event {
        public float time;
        public float[] values;
        public Event(float time, float[] values) {
            this.time = time;
            this.values = values;
        }
    }
    public static void ReGenerateLevel() {
        int num_bugs = 1000;
        bug_index = 0;
        bug_spawns = new Event[num_bugs];
        Random.InitState(42);
        float time =0;
        for(int i=0; i< num_bugs; i++) {
            time += 2f;
            bug_spawns[bug_index++] = new Event(time, new float[]{Random.Range(0f,1f), Random.Range(0f,1f)});
        }
        bug_index = 1;
    }
    public static bool IsTimeForBug() {
        return bug_spawns[bug_index].time < Time.time;
    }
    public static float[] NextBug() {
        return bug_spawns[bug_index++].values;
    }
    public static bool IsTimeForPlatform() {
        return platform_spawns[platform_index].time < Time.time;
    }
    public static float[] NextPlatform() {
        return platform_spawns[platform_index++].values;
    }
    public static bool IsTimeForDrop() {
        return drop_spawns[drop_index].time < Time.time;
    }
    public static float[] NextDrop() {
        return drop_spawns[drop_index++].values;
    }
}
