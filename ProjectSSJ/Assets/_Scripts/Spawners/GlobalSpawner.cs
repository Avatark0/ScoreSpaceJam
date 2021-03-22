using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalSpawner {
    public static float bug_spawn_min_seconds = 0f;
    public static float bug_spawn_max_seconds = 3f;

    // At the beginning, platforms show up every 2-5 seconds.
    public static float platform_spawn_min_seconds = 2f;
    public static float platform_spawn_max_seconds = 5f;
    // That rate is increased by (time/30s);
    public static float platform_spawn_scaling_seconds = 30f;

    public static float drop_spawn_min_seconds = 1f;
    public static float drop_spawn_max_seconds = 3f;
    // That rate is increased by (time/30s);
    public static float drop_spawn_scaling_seconds = 30f;

    private static int bug_index;
    private static Event[] bug_spawns;
    private static int platform_index;
    private static Event[] platform_spawns;
    private static int drop_index;
    private static Event[] drop_spawns;
    private static System.Random random;
    private static float game_start_time;
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
        platform_spawns = new Event[10000];
        drop_spawns = new Event[10000];
        random = new System.Random(43);
        float time =0;
        for(int i=0; i< bug_spawns.Length; i++) {
            // Bugs are separated by between 0 and 3 seconds.
            float delta = (float)random.NextDouble()*(bug_spawn_max_seconds - bug_spawn_min_seconds) + bug_spawn_min_seconds;
            time += delta;
            bug_spawns[i] = new Event(time, new float[]{(float)random.NextDouble(),(float)random.NextDouble()});
        }
        time = 0;
        for(int i=0; i< platform_spawns.Length; i++) {
            float delta = (float)random.NextDouble()*(platform_spawn_max_seconds - platform_spawn_min_seconds) + platform_spawn_min_seconds;
            float scale = time/platform_spawn_scaling_seconds + 1;
            time += delta/scale;
            platform_spawns[i] = new Event(time, new float[]{(float)random.NextDouble(),(float)random.NextDouble()});
        }
        time = 0;
        for(int i=0; i< drop_spawns.Length; i++) {
            // At the beginning, acid drops show up every 1-3 seconds.
            float delta = (float)random.NextDouble()*(drop_spawn_max_seconds - drop_spawn_min_seconds) + drop_spawn_min_seconds;
            float scale = time/drop_spawn_scaling_seconds + 1;
            time += delta/scale;
            drop_spawns[i] = new Event(time, new float[]{(float)random.NextDouble(),(float)random.NextDouble()});
        }
        ReInitLevel();
    }
    public static void ReInitLevel() {
        bug_index = 0;
        platform_index = 0;
        drop_index = 0;
        game_start_time = Time.time;
    }
    public static bool IsTimeForBug() {
        bug_index %= bug_spawns.Length;
        return bug_spawns[bug_index].time < Time.time - game_start_time;
    }
    public static float[] NextBug() {
        bug_index %= bug_spawns.Length;
        return bug_spawns[bug_index++].values;
    }
    public static bool IsTimeForPlatform() {
        platform_index %= platform_spawns.Length;
        return platform_spawns[platform_index].time < Time.time - game_start_time;
    }
    public static float[] NextPlatform() {
        platform_index %= platform_spawns.Length;
        return platform_spawns[platform_index++].values;
    }
    public static bool IsTimeForDrop() {
        drop_index %= drop_spawns.Length;
        return drop_spawns[drop_index].time < Time.time - game_start_time;
    }
    public static float[] NextDrop() {
        drop_index %= drop_spawns.Length;
        return drop_spawns[drop_index++].values;
    }
}
