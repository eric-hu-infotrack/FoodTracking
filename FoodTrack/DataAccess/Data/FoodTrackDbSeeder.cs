using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTrack.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodTrack.DataAccess.Data
{
    public static class FoodTrackDbSeeder
    {
        public static async Task Seed(FoodTrackDbContext db)
        {
            await db.Database.MigrateAsync();
            //if any error occurs, rollback the entire transaction(avoid database inconsistency)
            using (var transaction = await db.Database.BeginTransactionAsync())
            {
                DateTime utcNow = DateTime.UtcNow;
                if (!await db.Categories.AnyAsync())
                {
                    List<Category> categories = new List<Category>
                    {
                        new Category
                        {
                            CreatedAt = utcNow,
                            Name = "Groceries",
                            ProfilePath = "https://cdn.pixabay.com/photo/2015/09/02/12/25/basket-918416_960_720.jpg"
                        },
                        new Category
                        {
                            CreatedAt = utcNow,
                            Name = "Sausage Sizzle",
                            ProfilePath = "https://cdn.pixabay.com/photo/2018/07/08/20/18/grill-party-3524649_960_720.jpg"
                        },
                        new Category
                        {
                            CreatedAt = utcNow,
                            Name = "Burger",
                            ProfilePath = "https://cdn.pixabay.com/photo/2015/04/20/13/25/burger-731298_960_720.jpg"
                        },
                        new Category
                        {
                            CreatedAt = utcNow,
                            Name = "Bacon and Egg Breakfast",
                            ProfilePath = "https://cdn.pixabay.com/photo/2020/02/06/13/43/breakfast-4824364_960_720.jpg"
                        },    
                        new Category
                        {
                            CreatedAt = utcNow,
                            Name = "Friday Night",
                            ProfilePath = "https://cdn.pixabay.com/photo/2016/05/26/19/37/chips-potatoes-1418192_960_720.jpg"
                        },
                    };
                    db.Categories.AddRange(categories);
                    await db.SaveChangesAsync();
                }
                if (!await db.Items.AnyAsync())
                {
                    List<Item> items = new List<Item>
                    {
                        new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Gluten Free",
                            ProfilePath = "http://t0.gstatic.com/images?q=tbn%3AANd9GcSbM44OhcTbxv5l_gxEbQOMa-7nl7DxJXhBkEKtCvC36re7EQxPJleHqmpd8A&usqp=CAc"
                        },
                        new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Rasin Toast",
                            ProfilePath = "http://t0.gstatic.com/images?q=tbn%3AANd9GcRn8k90UGmk6gHhSVwfgFyD7LoxTRzSArJh32uA_zXjTblewkERBMXi9-d1hA&usqp=CAc"
                         },
                         new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Burgen Rye",
                            ProfilePath = "https://cdn0.woolworths.media/content/wowproductimages/large/232834.jpg"
                         },
                          new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Raw Sugar",
                            ProfilePath = "http://t0.gstatic.com/images?q=tbn%3AANd9GcTXUB4GnanJWf2Cv5Hs7H0ZPpz24Wx62b5TQExTsMeKfdEJPI1KUhszFd-8qA&usqp=CAc"
                         },
                           new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Sugar",
                            ProfilePath = "http://t0.gstatic.com/images?q=tbn%3AANd9GcSKxXv172s8PTsTcfXhB_0EIy3Uu7Ah-BnNlU679BbUynhW89E0mo5TKn0fic0&usqp=CAc"
                         },
                            new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Sea Salt",
                            ProfilePath = "http://t0.gstatic.com/images?q=tbn%3AANd9GcRS5RgySCpTT7zmZXzWqTpy_DQN9LZogu6Xj9phG3r1SXaMYCim5XYAsQ1wPw&usqp=CAc"
                         },
                             new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Pepper",
                            ProfilePath = "http://t0.gstatic.com/images?q=tbn%3AANd9GcS6-t0qkbxgi-ZuTnzcs41rHeQlWbc__SpXDk28Lrm0wrgrePmO_DkoIuzBh4Y&usqp=CAc"
                         }, new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Butter",
                            ProfilePath = "http://t0.gstatic.com/images?q=tbn%3AANd9GcSp_5oPtYPOfCmRILfF2JUnAWUuqDLbYwBzXoghPsmtK31jcXMFBp0KqylDEQ&usqp=CAc"
                         }, new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Chesse",
                            ProfilePath = "http://t0.gstatic.com/images?q=tbn%3AANd9GcTnqhPb0oJgpYW76wY5Syz5JwAHrPXvxlbFm4uj97HIZZ5ddbbx25yRUlj9tw&usqp=CAc"
                         }, new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Kraft Cheese",
                            ProfilePath = "http://t0.gstatic.com/images?q=tbn%3AANd9GcRFgW2gy8OD3FIjJeCQcRMVeKzES9ctCqVoMGVHKaOKiac9WfRGhT7YW4ojiBeTmThI9AsI_6eQ&usqp=CAc"
                         }, new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Cream Cheese",
                            ProfilePath = "http://t0.gstatic.com/images?q=tbn%3AANd9GcTs05Gj7-sLKYi0_TM7nCO5XdAZkzxiwVS_W1OjrbivKyws2b1ZQqhTyBFAMLg&usqp=CAc"
                         }, new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Full Cream Milk",
                            ProfilePath = "data:image/jpeg;base64,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"
                         }, new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Light Milk",
                            ProfilePath = "http://t0.gstatic.com/images?q=tbn%3AANd9GcRUp3iLAYMt95xGBV-mnbtM4xPL5pjbgrnxm1_tJBlgmBqLEPmh7GeLouUlwRA&usqp=CAc"
                         }, new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Soy Milk",
                            ProfilePath = "http://t0.gstatic.com/images?q=tbn%3AANd9GcS86t67c4IP6aIGB46Ro8ZIfFvi_XBoaqvdvQbFgPo3bcGxaSl0rclaqcxEAA&usqp=CAc"
                         }, new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Almond Milk",
                            ProfilePath = "http://t0.gstatic.com/images?q=tbn%3AANd9GcR3H9EGB5lYIQS0xhFEucqbUTyCqd6y4TQn2jLzD2zh4g5q_QsVOEXAKGeLq24&usqp=CAc"
                         }, new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Beef Sausages",
                            ProfilePath = "http://t0.gstatic.com/images?q=tbn%3AANd9GcSfWPI1EHR-4iHA4RR504WKgNXpRGhz6f0bkh-rF0Qp8nzhB6wPDjwXZQjprXc&usqp="
                         },
                        new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Beef Sausages",
                            ProfilePath = "http://t0.gstatic.com/images?q=tbn%3AANd9GcSfWPI1EHR-4iHA4RR504WKgNXpRGhz6f0bkh-rF0Qp8nzhB6wPDjwXZQjprXc&usqp="
                         },
                        new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Pork Sausages",
                            ProfilePath = "http://t0.gstatic.com/images?q=tbn%3AANd9GcSpgs_muC2kdKYeOWpN5hllsVuRwmBOfoWRw1jOAJJEEamyDVzRBnFXx2b9v8k&usqp=CAc"
                         }, new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Chicken Sausages",
                            ProfilePath = "http://t0.gstatic.com/images?q=tbn%3AANd9GcTiL8IuFuO05J5l5lVtHcRbACtZrfkpkY7jJX2jci2pwgoQU76FLpDMMDH64Q&usqp=CAc"
                         }, new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Veggie Pattys",
                            ProfilePath = "hhttp://t0.gstatic.com/images?q=tbn%3AANd9GcQ4U8hKVUxBGdh7YCwlh95jAuYq7RrELE2B8swWgLZK4-O447-xt-XFOHJsHg&usqp=CAc"
                         }, new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Tasty Cheese",
                            ProfilePath = "http://t0.gstatic.com/images?q=tbn%3AANd9GcQH-OsgDiejrHWFf5QH0MYfLy6nJvjmBFQmi9bunV4DzuF4yhQg3l068zF1oDc&usqp=CAc"
                         },
                        new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Slided Onions",
                            ProfilePath = "data:image/jpeg;base64,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"
                         },  
                              new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "White Rolls",
                            ProfilePath = "data:image/jpeg;base64,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"
                         },
                              new Item
                        {
                            CreatedAt = utcNow,
                            QuantityInTotal = 0,
                            Name = "Wholemeal Rolls",
                            ProfilePath = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxISEhUSExMVFhUVFRcWGBgYGBYVGBYWFRUYGBgYFhsaHSggGRolGxUVITEhJSkrLi4uFx8zODMsNygtLisBCgoKDg0OGhAQGy0lHyUtLTUwLS0yLS81LS0tLS0tLS0tLS0tLS0tLy0tLS0tLS0tLS0tLS0tLS0tLSstLS0tLf/AABEIAOEA4QMBIgACEQEDEQH/xAAbAAEAAgMBAQAAAAAAAAAAAAAAAwUCBAYBB//EAD0QAAIBAgMFBQYFAgQHAAAAAAABAgMRBCExBRJBUWFxgZGh8AYTIrHB8TJCUtHhcoIUYpKiFiMkM0NEc//EABkBAQADAQEAAAAAAAAAAAAAAAABAgMEBf/EACMRAQACAgIDAAMBAQEAAAAAAAABAgMRIUEEEjEiMlFCUhP/2gAMAwEAAhEDEQA/APuIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA2eKSA9AOb27th2lCDskndrVvkuhlmzVxV9rNMeOck6ht7X29Gk92EXOV8+SWve+iKWftZUmm4x3c7JOLUuHPh3FRvb1s81q+/Rd6fgYRjG+6nzeea7L6anj5PMy2nidPSp42OscxtZy21Wck/ePnqrJdlrFxsvbzclCrbPSWmb0vbI5hKzTyy9ZMzlVjbL+blMfk5Kzva18NLRrT6MDXwEm6UG9XCLfekbB78TuNvImNToABKAAAAAAAAAAAAAAAAAAAAAwI8RXjCLlJ2SOax/tDN5Q+Fc9X/Brbb2l7ydr/AnZLn1KarUzy1evYszyPJ8y0z60nh6ODxoiN2+tmpiZTu22+Obfr7mCrvhf+DSlO+S00v67SRNX9P7s4Jm312RELjCbSqpNb7aatztflfRlXOMlNptN63fLgkuBPQVvXMp/aXEODp7rupb91lm4qNk/FibWniUaiJ3DbhUvksl5tdvEzbstUuvLK7KPETqRl7yEN7LO0knkuGfJES2pBr8T7Fa93fJ/bgTCVxUxNl9V14ldiNpqEkrXvKzjfdur8HbL7dhT43bMUm7qy19cez9yTYK396rNXySUdbLWz68W/DREa/1Jvp3U/aPESX5YxSyjBtPJZLPPpqa8dpuWtSpfrKSay0K3DLJ2bS4Lkrc+Rt0sO5ZuTtle6T3l2PTtLWy3t9lEY6V+Q3qW06qtatNdsr/ADLXZvtDUjlVW/H9StdfR+syk95Z6K3Yr+J6q175/wAZF6Z70ncTKlsVLRqYd9gsfTqq8JXtqtGu1cDZPnNHGTi1Ja3+Hdyfn8jo9k+0ylaNVbr/AFfuv28j08Hm1txfiXDl8W1ea8w6MHkZJ5rNHp3OQAAAAAAAABjKaWrRFLFwX5vDMibRH2UxEz8Tg1JY5cIyfkRSxs+EYrtd/kZzmpHa0Y7SsCo9pcZuUt1azuv7Vr9PEznian6kuxfuct7V4qW8ouTdo38b349PI5vI8mPSYq3wYfzjasxGKt99CvqV78dep7DD73xbySSzu9Oq9cTOGFjJrdi5Li2t3hw58DyI3Px6e4h5QxlP4VJ2zVr8+i8DfprpZLO99f34GnDBw3k5WVssmpW6ztpxV9OpuyoSzUE5Wtdt2S6LoRPsiJhJUulfdlu8/wAunXLI5Pa05YivGEPw04u73fzTayS4u0fMsNv45wioJrfldRzb3bZt25LPUi2PRUErZvPPi+d+pH68n1uYXBxjrvS7edv0/cneHpXaVOC4vKKv1yRnTqx1TTSyyztb7mW5GST1yVmtefhkVldrVdi4adlKjTdn+mOTXHQzpbNpJvcTg12tX63ZspX4ddb5ozbildd9rE76NQ0XeL3b5/PPVcywUlup31zVuJz1XHP/ABEY3eUXx1as15F3TqLdzVstOq19aZE8IYRl8WevZ156cRDehdvS98vPUk91G2TvyXFd66nibzTVl8/X1GhrOrJNO/wt3Wtr9bsnp4hNN+N07p3ty5WzMZQk/wBPk1qvDK5hOnvPdlJJPR58tJcb5eQglfezPtBuS91OV4N7vKzvqm9VnmjuT5RCKglFeObv1TevE+kbCrueHpybu92zfVO30PW8DNNomk9PO8vHEflDfAB6LiAABBjJNQk07NL6lc6knrJvvsWlaKaafFW8TnYy3ZOMtU/E5fI3GpbYtfG25pcvXaPe9TTqYmEdWY/41LgcU3dPq3nV6GtW2hGOV8+Sz+xWYraTkmoq3B55vv4FXOd00+/iZXz6+NaYd/VxU23yj5peu4rNqSVXOSeiWSvz59pBTtFc+rs33c+BlfPTJ93PM5rZLW+uiuOtfiKpQvBQi91c2m7y5teGRqbSn7tLdvOTaStldvVvLJJX4Fk5WTvnl32z4GhiZOEXNQ3pKOSe7eV+CeizS5LQtS/St6dwip05L4nuqTzbukovlnZW65nmL23Rpw3YtSqPKykmkv7XbguJwmP25iMR8LjuRX5En/ubzZ7Sw07aJd1vmdlcET+0uacn/LewU3UrVKkm277qvwjHW3JN30OlwKtFZ6/vx6nJ7LnuuSfPnbXjoX9Cq4pO6ay05vLPpdHFm4vLqxz+MLmNO19dePF8fkT3Vk1fK3wrnfhY0KWI735WNxVVpvJvk2ufdy1KxK7FYxXs1btfy4ENWblxbu156/M2401UyaVo6t2ata9+psVMJaNk/dx6Wc2ut/w6EVrNviLXirjdq4OoqkKlnHdks+jdnful5FzSrNtWeV72tbXS1vWSNbb8WoO287r8Ut53y5X146Fb7NbSjWvFSTcGoy7efOz9aFr47VrtWuSJnTo03rBt21TevYKONbyeufR39XLGgopKzv238UiXEypNfElfpFpq2vDLvEUt0TkqqKkk+7O+azz4GVPELO90+/t7DYxOzHZSg3ZW7k38s7lZUp265/PW/kRMdStFt8wmr1lJavvPpHsnL/paa5XX+5+J82w9NzkoLWT+7y6XPoex8Q6aUJNbvD/L/B2+Db1vuXL5fNdQvQEwey8wAAGFRZHO7Yp/Epdz+jOlZWbSw90yt6+0aWrOp2o0unZ6Zp7WqNRsuNr25eZuUNXF6oyrRvZcNLdWnn5PwPHvSeYehW8fXKSxHT6eXcvEzWI42z07OXaRbVo+7nJPRZ68+PgQ0alsk23ro7a82vVjjl1xKyWeXZf5/sewhK9k9fmQ4ed/yrvy8P5PcRWmoScVaSVouybvLK/d1yEV3JM6hlOvuzdO6bglvPk7JtN6XzWXUjqT31uKK3pK3OKV1d21sR7PwO4pRqWcqkr5q+9vZu70cm43tyS5CtNxq0/iSUpbrTcUnF/ljzd0tDecVemEZJZ0djQk3KUYqV89NefDXXvNhbJppaeX3Mtn1YuVT8qW7FWeqSdu1ZlxhMND8b7r537PBkUmdFtQ4Lb2wJL/AJtBZ3tmm4yf6cvuUqlVpQ361KdON91uaahd8N7h32PrWMxUpQqJRcFGN7tW1bdly0XicZKcqlRUnmqkt156wbz8FcrltG4iY2tjiZiZVGExmSaeXB2vr1XC3aWEMU28rd+nq3zN6p7D0FnGU6f9M2l4J28iP/hG3/tVv9NP5uBnOP8Akrxf+tjDTeb+GTWmqW9rm380v4yxG2YRdpy3p2TVODcnfjeKWefLQxpezFJfjqV6i5SqNRf9sMmWeCwdGit2lThBf5Yr6GtZ9Y0ztzO3H7S2bisX+JujStbd/wDJK+u9JL4csrLkc8vZ2tg5+9oXTjxzz/qzzPq9VuWifdkak8DKXDxzZeMsxx0rNIcfg/bSg/hxVKdKXGcPjg2lbR3kuzNHRbO2zQqW93iKdS3DeW9/dBWd/wBl1JanszTn+KEX3I15eweElrRTJ96o9W3PH3unJ2aWTta3dxKbH7TpU9ZRV9Lu8n2LXwLSn7EYVZe7yXDelbwuWWC9mqFP8NOK7ErmU1iZXidKP2cVSrLfcHGPC903zb5HYUqTSJ6OFUV6RPvRWrX1NaVZ2sn2ZjHH4ZP4eD5fwXSZzUsVFaXfkWexsQ5prgmrcdT0fHyz+kuTLT/ULIAHY5wjrQuiQAc1j6G7LeXY/oV7x6jNOV7S+G7aspcL3ej07zpcfQujmMVs+FS8J38X42v2HD5VNflDpwW3+MtbbdF7inFX3VbJ55ZZeGnac66nFu/Bp2a9aljtHGSoQcK05PTdm07WX6nwlzb1tfmUrq0pPejK11orNd2fU8zJMb27sccabPvmtOnC61LzBR+G7SlyWWaurvN8r8SijioJ5JaWd1fX1oWmzdspNRnpZ562fG3EyrNYnctLbmOFuoJ6xkr5LJc73WdnlyzV2V22sB+GUd2LTyk1vSd1ZpX6dmnQkxirVmnQruEGknKG7Jvmk3dJ82S0tj6OTlO2m87pdbL4b5vO1+p0zb+MIqpNmV3Cct6Tk4x+JrRPgrrK9uH3fUUZXgmpq104vszu79rI1sxNWtlyWSKjGPEYVJRhKpTTTioRi5KKTTjJuS55O3aVrx0meVxt7E7sHeSaaVlfPq1d5+HE5HZFCU614rKF8+r4ZdD2nRxeMl/2fcQespfFO19FbJHZbM2VCjBQislzz8SvrNre0p9orXSCnQk+SJ44M3vhXH6/M9dZLg+/I0/84Um7Vjgly9eRLHCoyliOVl5mLr34t+XyJisQr7S9WGXrIe4iuK+vkRup6+55dv7fYmKxPxEzKRxj6sj3ejyIlSlyM1hGa1wXn5VWclY7PergiOeIZsRwHazZhgOn1Na+LfvUM5zVVLqt9fM9jSnLSL+RewwJNDCGseHHcqznnqFLS2VOWrivG/kXOzMH7pNXvd30sbEKNiVRNqYKUncM7ZLW4l6ADZmAADCrG6Oc2vR3fi7n9GdMV+0aCafUrevtGk1nU7c6sPvrO2friVWJ9j8NN3dOzeri3BvvjYusHNxcoPOxs+/XBL5/I8e2L1nT0IybhyM/YSk9KldL/wCkvmzYw3sJhl+JTn/XUnJeDbR0jrvn4L9zD31+b77/ACRHqn2llhsHCnFRilFLRLKxM3H7GrKfDL12mSUnz8/4Ratd/IVmf6ndRcvHIxlV7CJUny+ny/czjh2/t+9zWMGSemc5Kx2xdQwlU9fwzbhgn1NingOhrXxLdypOeOoVd29L9yf8Gaoy9fwXEMCTRwiNY8SvcqTnnpSLCN8SaOB7X2l1HDozVNGsYMcdKTktPapp4HoTxwRY2PTSIiPim9tOODRLHDInBIjVJGaiegBYAAAAAAAAAACOtC6JABzmOwr3t5Lo+z18yD3MvT/b9zo6tBMxWERjbBS07lpXJaI1Cihhn6/m5PDAt6+ZdRoIzUEWjFSPkIm9p7VlLA24GxHBm5Y9NFGqsIiSOHSJgBioI9segAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA//9k="
                         }
                    };
                    db.Items.AddRange(items);
                    await db.SaveChangesAsync();
                }
                if (!await db.CategoryItems.AnyAsync())
                {
                    List<CategoryItem> categoryItems = new List<CategoryItem>
                    {
                        new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 1,
                            FrequencyRate = 1,
                            RowOrder = 4,
                            CategoryId = 1,
                            ItemId = 1
                        },
                        new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 2,
                            FrequencyRate = 1,
                            RowOrder = 5,
                            CategoryId = 1,
                            ItemId = 22
                        },
                        new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 2,
                            FrequencyRate = 1,
                            RowOrder = 6,
                            CategoryId = 1,
                            ItemId = 21
                        },
                        new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 1,
                            FrequencyRate = 1,
                            RowOrder = 7,
                            CategoryId = 1,
                            ItemId = 20
                        },
                        new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 1,
                            FrequencyRate = 1,
                            RowOrder = 8,
                            CategoryId = 1,
                            ItemId = 19
                        },new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 3,
                            FrequencyRate = 1,
                            RowOrder = 9,
                            CategoryId = 1,
                            ItemId = 18
                        },new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 2,
                            FrequencyRate = 1,
                            RowOrder = 10,
                            CategoryId = 1,
                            ItemId = 17
                        },new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 6,
                            FrequencyRate = 1,
                            RowOrder = 11,
                            CategoryId = 1,
                            ItemId = 16
                        },new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 7,
                            FrequencyRate = 1,
                            RowOrder = 12,
                            CategoryId = 1,
                            ItemId = 15
                        },new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 4,
                            FrequencyRate = 1,
                            RowOrder = 13,
                            CategoryId = 1,
                            ItemId = 14
                        },new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 2,
                            FrequencyRate = 1,
                            RowOrder = 14,
                            CategoryId = 1,
                            ItemId = 13
                        },new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 36,
                            FrequencyRate = 1,
                            RowOrder = 15,
                            CategoryId = 1,
                            ItemId = 12
                        },new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 30,
                            FrequencyRate = 1,
                            RowOrder = 16,
                            CategoryId = 1,
                            ItemId = 11
                        },new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 20,
                            FrequencyRate = 1,
                            RowOrder = 17,
                            CategoryId = 1,
                            ItemId = 10
                        },new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 6,
                            FrequencyRate = 1,
                            RowOrder = 18,
                            CategoryId = 1,
                            ItemId = 9
                        },new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 6,
                            FrequencyRate = 1,
                            RowOrder = 4,
                            CategoryId = 2,
                            ItemId = 7
                        },new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 6,
                            FrequencyRate = 1,
                            RowOrder = 5,
                            CategoryId = 2,
                            ItemId = 6
                        },new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 5,
                            FrequencyRate = 1,
                            RowOrder = 6,
                            CategoryId = 2,
                            ItemId = 5
                        },new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 7,
                            FrequencyRate = 1,
                            RowOrder = 7,
                            CategoryId = 2,
                            ItemId = 4
                        },new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 1,
                            FrequencyRate = 1,
                            RowOrder = 8,
                            CategoryId = 2,
                            ItemId = 3
                        },new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 6,
                            FrequencyRate = 1,
                            RowOrder = 9,
                            CategoryId = 2,
                            ItemId = 2
                        },new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 10,
                            FrequencyRate = 1,
                            RowOrder = 10,
                            CategoryId = 2,
                            ItemId = 23
                        },new CategoryItem
                        {
                            CreatedAt = utcNow,
                            DefaultQuantityNeeded = 6,
                            FrequencyRate = 1,
                            RowOrder = 11,
                            CategoryId = 2,
                            ItemId = 24
                        }
                    };
                    db.CategoryItems.AddRange(categoryItems);
                    await db.SaveChangesAsync();
                }
                transaction.Commit();
            }
        }
    }
}
