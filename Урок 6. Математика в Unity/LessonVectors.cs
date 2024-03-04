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
            float dx = c2.x - c1.x;
            dx *= dx;
            float dy = c2.y - c1.y;
            dy *= dy;
            var distance = Mathf.Sqrt(dx + dy);

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
            Vector2 vectorAP = point - start;
            Vector2 vectorAB = end - start;

            float skewProduct = SkewProduct(vectorAB, vectorAP);
            float pointRelativeLine = skewProduct switch
            {
                > 0 => -1,
                < 0 => 1,
                _ => 0f
            };
            return pointRelativeLine;
        }

        public static float SkewProduct(Vector2 vector1, Vector2 vector2)
        {
            return vector1.x * vector2.y - vector1.y * vector2.x;
        }


        /**
        * Простая (2 балла)
        *
        * Определить, лежит ли точка point внутри или на периметре прямоугольника,
        * который задается двумя точками start и end
        */
        public static bool IsPointInRectangle(Vector2 start, Vector2 end, Vector2 point)
        {
            return IsPointInsideOrOnRectangle(start, end, point);
        }

        private static bool IsPointInsideOrOnRectangle(Vector2 start, Vector2 end, Vector2 point)
        {
            float minX = Mathf.Min(start.x, end.x);
            float maxX = Mathf.Max(start.x, end.x);
            float minY = Mathf.Min(start.y, end.y);
            float maxY = Mathf.Max(start.y, end.y);

            return point.x >= minX && point.x <= maxX && point.y >= minY && point.y <= maxY;
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
            int startMin = Mathf.Min(start.x, start.y);
            int startMax = Mathf.Max(start.x, start.y);
            int endMin = Mathf.Min(end.x, end.y);
            int endMax = Mathf.Max(end.x, end.y);


            if ((startMin > 8) || (startMax > 8) || (endMin > 8) || (endMax > 8))
            {
                throw new IllegalArgumentException("Invalid coordinates");
            }

            if ((startMax == endMax) && (startMin == endMin))
            {
                return 0;
            }
            if (Mathf.Abs(startMax - endMax) == Mathf.Abs(startMin - endMin))
            {
                return Mathf.Abs(startMax - endMax);
            }
            if (Mathf.Abs(startMax - endMax) > Mathf.Abs(startMin - endMin))
            {
                return Mathf.Abs(startMax - endMax);
            }
            else
            {
                return Mathf.Abs(startMin - endMin);
            }
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
            float distanceCentrPointAndRayStartPoint = Vector3.Distance(center, ray.origin);
            if (distanceCentrPointAndRayStartPoint <= radius)
            {
                return false;
            }

            Vector3 pointInRay = ray.GetPoint(Mathf.Floor(Vector3.Distance(ray.origin, center)));
            float distanePointInRayAndCentrPoint = Mathf.Floor(Vector3.Distance(pointInRay, center));

            if (distanePointInRayAndCentrPoint <= radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}