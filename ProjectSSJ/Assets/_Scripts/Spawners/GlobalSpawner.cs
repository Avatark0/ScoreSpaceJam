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
    private static System.Random random;
    private class Event {
        public float time;
        public float[] values;
        public Event(float time, float[] values) {
            this.time = time;
            this.values = values;
        }
    }
    static GlobalSpawner() {
        bug_spawns = new Event[1000];
        platform_spawns = new Event[1000];
        drop_spawns = new Event[1000];
        random = new System.Random(42);
        float time =0;
        for(int i=0; i< bug_spawns.Length; i++) {
            time += 2f;
            bug_spawns[i] = new Event(time, new float[]{(float)random.NextDouble(),(float)random.NextDouble()});
        }
        time = 0;
        for(int i=0; i< platform_spawns.Length; i++) {
            time += 2f;
            platform_spawns[i] = new Event(time, new float[]{(float)random.NextDouble(),(float)random.NextDouble()});
        }
        time = 0;
        for(int i=0; i< drop_spawns.Length; i++) {
            time += 2f;
            drop_spawns[i] = new Event(time, new float[]{(float)random.NextDouble(),(float)random.NextDouble()});
        }
        ReInitLevel();
    }
    public static void ReInitLevel() {
        bug_index = 0;
        platform_index = 0;
        drop_index = 0;
    }
    public static bool IsTimeForBug() {
        bug_index %= bug_spawns.Length;
        return bug_spawns[bug_index].time < Time.time;
    }
    public static float[] NextBug() {
        bug_index %= bug_spawns.Length;
        return bug_spawns[bug_index++].values;
    }
    public static bool IsTimeForPlatform() {
        platform_index %= platform_spawns.Length;
        return platform_spawns[platform_index].time < Time.time;
    }
    public static float[] NextPlatform() {
        platform_index %= platform_spawns.Length;
        return platform_spawns[platform_index++].values;
    }
    public static bool IsTimeForDrop() {
        drop_index %= drop_spawns.Length;
        return drop_spawns[drop_index].time < Time.time;
    }
    public static float[] NextDrop() {
        drop_index %= drop_spawns.Length;
        return drop_spawns[drop_index++].values;
    }
}
