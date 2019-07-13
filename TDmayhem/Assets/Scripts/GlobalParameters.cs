using System.Collections;
using System.Collections.Generic;

public class GlobalParameters 
{
    // Start is called before the first frame update
    public static GlobalParameters Params;
    public static int Global_GUID_length;
        
    private void Awake() {
        Params = this;
        Global_GUID_length = 5;
    }
}
