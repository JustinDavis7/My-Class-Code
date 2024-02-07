module Assn2b
(
myLength,
convertInttoStringLeft,
convertInttoStringRight
) where
import Data.Char
--Part02_Problem 1
--foldl execution -> ((((6)*5)*3)*8)
--foldr execution -> (8*(3*(5*(6))))

--Part02_Problem 1
myLength :: [a] -> Int
myLength = foldl (\x _ -> x + 1) 0

step x s = intToDigit x : s

--Part02_Problem 3.1
convertInttoStringLeft :: [Int] -> [Char]
convertInttoStringLeft = foldl (\x s-> intToDigit s : x) []

--Part02_Problem 3.2
convertInttoStringRight :: [Int] -> [Char]
convertInttoStringRight = foldr (\x s->intToDigit x : s) []
