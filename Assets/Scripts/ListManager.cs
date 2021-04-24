
public class ListManager
{
    private static ListManager manager;
    public ObjectsList list;
    
    public static ListManager onInit() {
        if (manager == null) {
            manager = new ListManager();
        }
        return manager;
    }
}
