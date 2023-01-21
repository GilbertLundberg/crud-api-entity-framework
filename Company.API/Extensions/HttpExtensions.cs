using Company.Data.Interfaces;

namespace Company.API.Extensions;

public static class HttpExtensions
{
    //Get all
    public static async Task<IResult> HttpGetAsync<TEntity, TDto>(this IDbService db) where TEntity : class, IEntity
    where TDto : class =>
    Results.Ok(await db.GetAsync<TEntity, TDto>());

    //Get by id
    public static async Task<IResult> HttpSingleAsync<TEntity, TDto>(this IDbService db, int id) where TEntity : class, IEntity where TDto : class
    {
        var result = await db.SingleAsync<TEntity, TDto>(e => e.Id.Equals(id));
        if (result == null) return Results.NotFound(result);
        else return Results.Ok(result);
    }

    //Post

    public static async Task<IResult> HttpPostAsync<TEntity, TDto>(this IDbService db, TDto dto) where TEntity : class, IEntity where
    TDto : class
    {
        if (dto is null) return Results.BadRequest();
        var entity = await db.AddAsync<TEntity, TDto>(dto);


        if (await db.SaveChangesAsync())
        {
            return Results.Created(db.GetURI<TEntity>(entity), entity);
        }

        return Results.BadRequest();
    }

    //Update
    public static async Task<IResult> HttpPutAsync<TEntity, TDto>(this IDbService db, TDto dto, int id)
    where TEntity : class, IEntity where
    TDto : class
    {
        try
        {
            if (dto is null) return Results.BadRequest();
            if (!await db.AnyAsync<TEntity>(e => e.Id.Equals(id)))
                return Results.NotFound();

            db.Update<TEntity, TDto>(id, dto);

            if (await db.SaveChangesAsync())
                return Results.NoContent();
        }

        catch (Exception ex)
        {
            return Results.BadRequest($"Couldn't update the {typeof(TEntity).Name} entity.\n{ex}.");
        }
        return Results.BadRequest();

    }

    //Delete
    public static async Task<IResult> HttpDeleteAsync<TEntity>(this IDbService db, int id) where TEntity : class, IEntity
    {
        {
            //try
            //{
            //    var success = await db.DeleteAsync<TEntity>(id);

            //    if (await db.SaveChangesAsync())
            //        return Results.NoContent();
            //}


            //catch (Exception)
            //{
            //    throw;
            //}
            //return Results.BadRequest();

            try
            {
                if (!await db.DeleteAsync<TEntity>(id)) return Results.NotFound();

                if (await db.SaveChangesAsync()) return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Couldn't delete the {typeof(TEntity).Name} entity.\n{ex}.");
            }

            return Results.BadRequest($"Couldn't delete the {typeof(TEntity).Name} entity.");

        }
    }

    //Delete reference entity
    public static async Task<IResult> HttpDeleteAsync<TReferenceEntity, TDto>(this IDbService db, TDto dto) where TReferenceEntity :
    class, IReferenceEntity where TDto : class
    {

        //try
        //{
        //    var success = db.Delete<TReferenceEntity, TDto>(dto);

        //    if (await db.SaveChangesAsync())
        //        return Results.NoContent();
        //}


        //catch (Exception)
        //{
        //    throw;
        //}
        //return Results.BadRequest();
        try
        {
            if (!db.Delete<TReferenceEntity, TDto>(dto)) return Results.NotFound();

            if (await db.SaveChangesAsync()) return Results.NoContent();
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Couldn't delete the {typeof(TReferenceEntity).Name} entity.\n{ex}.");
        }

        return Results.BadRequest($"Couldn't delete the {typeof(TReferenceEntity).Name} entity.");

    }

    //Post reference entity

    public static async Task<IResult> HttpAddAsync<TReferenceEntity, TDto>(this IDbService db, TDto dto) where TReferenceEntity : class, IReferenceEntity where
     TDto : class
    {

        try
        {
            var entity = await db.AddAsync<TReferenceEntity, TDto>(dto);


            if (await db.SaveChangesAsync())
            {
                return Results.NoContent();
            }
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Couldn't add the {typeof(TReferenceEntity).Name} entity.\n{ex}.");
        }


        return Results.BadRequest();

    }
}





