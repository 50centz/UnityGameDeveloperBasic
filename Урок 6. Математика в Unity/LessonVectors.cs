using Assets.DZ;
using System;
using UnityEngine;

namespace Sample
{
    public static class LessonVectors
    {
        // Максимальное количество баллов = 10

        ///Пример: Возвращает лежит ли точка point на внутри окружности с центром center и радиусом radius 
        public static bool IsPointInCircle(Vector2 center, float radius, Vector2 point)
        {
            return Vector2.Distance(center, point) <= radius;
        }

        ///Пример: Возвращает лежит ли точка point на отрезке (start, end) 
        public static bool IsPointOnLine(Vector2 start, Vector2 end, Vector2 point)
        {
            Vector2 vectorAP = point - start;
            Vector2 vectorAB = end - start;

            //Проверка коллинеарности векторов:
            float crossProduct = Vector3.Cross(vectorAP, vectorAB).z;
            if (Mathf.Abs(crossProduct) > float.Epsilon)
                return false;

            //Проверка проекций:
            float dotProduct = Vector2.Dot(vectorAP, vectorAB);
            float squaredLengthAB = vectorAB.sqrMagnitude;

            if (dotProduct < 0 || dotProduct > squaredLengthAB)
                return false;

            return true;
        }

        /**
         * Простая (1 балл)
         *
         * Проверить, лежит ли окружность с центром в (x1, y1) и радиусом r1 целиком внутри
         * окружности с центром в (x2, y2) и радиусом r2.
         * Вернуть true, если утверждение верно
         */
        public static bool CircleInsideCircle(
            Vector2 c1, float r1,
            Vector2 c2, float r2
        )
        {
            var distance = Mathf.Sqrt(Mathf.Pow((c2.x - c1.x), 2) + Mathf.Pow((c2.y - c1.y), 2));

            return r2 >= distance + r1;
        }

        /**
        * Простая (2 балла)
        *
        * Определить, с какой стороны лежит ли точка point относительно прямой, которая задается точками start и end.
        * Если точка относительно прямой расположена слева то вернуть -1, если справа, то 1, если точка лежит на прямой, то вернуть 0
        */
        public static float PointRelativeLine(Vector2 start, Vector2 end, Vector2 point)
        {

            float d = (point.x - start.x) * (end.y - start.y) - (point.y - start.y) * (end.x - start.x);
            if (d == 0)
            {
                return 0f;
            }
            else if (d < 0)
            {
                return -1f;
            }
            else
            {
                return 1f;
            }
        }


        /**
        * Простая (2 балла)
        *
        * Определить, лежит ли точка point внутри или на периметре прямоугольника,
        * который задается двумя точками start и end
        */
        public static bool IsPointInRectangle(Vector2 start, Vector2 end, Vector2 point)
        {
            if ((point.x <= start.x) || (point.x <= end.x) || (point.y <= start.y) || (point.y <= end.y))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /**
         * Средняя (3 балла)
         *
         * Определить число ходов, за которое шахматный король пройдёт из клетки start в клетку end.
         * Шахматный король одним ходом может переместиться из клетки, в которой стоит,
         * на любую соседнюю по вертикали, горизонтали или диагонали.
         * Ниже точками выделены возможные ходы короля, а крестиками -- невозможные:
         *
         * xxxxx
         * x...x
         * x.K.x
         * x...x
         * xxxxx
         *
         * Если клетки start и end совпадают, вернуть 0.
         * Если любая из клеток некорректна, бросить IllegalArgumentException().
         *
         * Пример: kingMoveNumber(Square(3, 1), Square(6, 3)) = 3.
         * Король может последовательно пройти через клетки (4, 2) и (5, 2) к клетке (6, 3).
         */
        public static int KingMoveNumber(Vector2Int start, Vector2Int end)
        {

            // король может ходить на одну клетку по горизонтали, вертикали или диагонали 
            // мин число ходов равно большему из абсолютного(x2 - x1) и абсолютного(y2-y1) 

            int x = start.x;
            int y = start.y;
            int xx = end.x;
            int yy = end.y;
            if (x > xx)
            {
                int temp = xx;
                xx = x;
                x = temp;
            }
            if (y > yy)
            {
                int temp = yy;
                yy = y;
                y = temp;
            }

            if ((x > 8) || (y > 8) || (xx > 8) || (yy > 8))
            {
                throw new IllegalArgumentException("Invalid coordinates");
            }


            if ((x == xx) && (y == yy))
            {
                return 0;
            }
            if ((xx - x) == (yy - y))
            {
                return xx - x;
            }
            if ((xx - x) > (yy - y))
            {
                return xx - x;
            }
            if ((xx - x) < (yy - y))
            {
                return yy - y;
            }

            

            return 0;

        }

        /**
        * Сложная (2 балла)
        *
		* Определить, пересекает ли луч сферу с центром center и радиусом radius (Описание алгоритмов см. в Интернете)
		* Если начало луча находится внутри или на поферхности сферы, то вернуть false
		* Луч задается через Unity type Ray 
        */
        public static bool RayCircleIntersect(Ray ray, Vector3 center, float radius)
        {
            
        }
    }
}