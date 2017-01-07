using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;

public class RouteConfig
{
    public static void RegisterRoutes(IRouteBuilder routes)
    {       
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}"
        );
        
        routes.MapRoute(
          name: "setDetails",
          template: "Workout/ExerciseDetails/{workoutId}/{exerciseId}",
          defaults: new { controller = "Workout", action = "ExerciseDetails" }
        );    
  }
}