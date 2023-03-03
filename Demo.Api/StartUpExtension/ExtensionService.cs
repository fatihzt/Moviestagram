using Demo.Business.Abstract;
using Demo.Business.Concrete;
using Demo.Core.Abstract;
using Demo.Core.Concrete;

namespace Demo.Api.StartUpExtension
{
    public static class ExtensionService
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUser, EfUser>();
            services.AddScoped<IMovieFavoriteListService, MovieFavoriteListManager>();
            services.AddScoped<IMovieFavoriteList, EfMovieFavoriteList>();
            services.AddScoped<ITvSeriesFavoriteListService, TvSeriesFavoriteListManager>();
            services.AddScoped<ITvSeriesFavoriteList, EfTvSeriesFavoriteList>();
            services.AddScoped<ILikedFavoriteListService, LikedFavoriteListManager>();
            services.AddScoped<ILikedFavoriteList, EfLikedFavoriteList>();
            services.AddScoped<ICommentedFavoriteListService, CommentedFavoriteListManager>();
            services.AddScoped<ICommentedFavoriteList, EfCommentedFavoriteList>();
            services.AddScoped<IItemOfMovieListService, ItemOfMovieListManager>();
            services.AddScoped<IItemOfMovieList, EfItemOfMovieList>();
            services.AddScoped<IItemOfTvListService, ItemOfTvListManager>();
            services.AddScoped<IItemOfTvList, EfItemOfTvList>();
        }
    }
}
