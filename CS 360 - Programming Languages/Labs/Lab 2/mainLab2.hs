import Assn2b
--Problem 1
gcdMine :: Integral a => a -> a -> a
gcdMine x y
    | y == 0 = x
    | otherwise = gcdMine y (rem x y)

gcdCheck x y = (myAnswer, correctAnswer, comment)
    where
    myAnswer = gcdMine x y
    correctAnswer = gcd x y
    comment = if myAnswer == correctAnswer then "Matches" else "Does not Match"

--Problem 2
fibSeq :: Int -> Int
fibSeq x | x == 0 = 0
fibSeq 1 = 1
fibSeq x = (+) (fibSeq (x - 1))(fibSeq (x - 2)) 

--Problem 3
count :: (Eq a, Num b) => a -> [a] -> b
count a [] = 0
count a(x:xs)
    | a == x = 1 + count a xs
    | otherwise = count a xs

--Problem 4
--sanitize :: String -> String
sanitize "" = ""
sanitize (x:xs)
    | x == ' ' = "%20" ++ sanitize xs
    | otherwise = x : sanitize xs

--Problem 5
multListBy10 :: Num a => [a] -> [a]
multListBy10 x = map (*10) x

--Problem 6
incrementList1 x = map (+1) x

incrementList2 x = map (succ) x

--Problem 7
containsDivisibleBy42 = any (\x -> x `mod` 42 == 0)

--Problem 8
powersOf10 = zipWith(\a b -> (a ^ b))  [10,10..10]

--Problem 9
stringStripper = reverse . dropWhile (== ' ') . reverse

--Problem 10
evenNumbers = all (\a -> a `mod` 2 == 0)

--Problem 11
addNotToList = map ("not "++)

--Problem 12
reverseListString = map (reverse)

--Problem 13
addNumbers = (\a b -> a + b)

--Problem 14
times4 = (\a -> a*4)

--Problem 15
secondElement = (\a -> head $ tail a)

--Problem 16
roundSquare = (\a -> round $ sqrt a)

--Problem 17 
splitSentence = (\a -> words a)

--Problem 18
triangles = map(\(a,b) -> (a, b, (sqrt $ a^2+b^2)))

main=do

--Problem 1
putStrLn "-Problem 1-"
putStrLn "Input: 18, 42"
putStr "Output: "
print(gcdMine 18 42)
putStrLn "gcdCheck... check"
print(gcdCheck 111 259)
print(gcdCheck 2945 123042)
print(gcdCheck (2*5*7)(7*23))
putStrLn""

--Problem 2
putStrLn "-Problem 2-"
putStrLn "Input: 20"
putStr "Output: "
print(fibSeq 20)
putStrLn ""

--Problem 3
putStrLn "-Problem 3-"
putStrLn "Input1: 7 [1,7,6,2,7,7,9]"
putStr "Output1: "
print(count 7 [1,7,6,2,7,7,9])
putStrLn "Input2: 'w' \"western oregon wolves\""
putStr "Output2: "
print(count 'w' "western oregon wolves")
putStrLn ""

--Problem 4
putStrLn "-Problem 4-"
putStrLn "Input1: \"http://wou.edu/my homepage/I love spaces.html\""
putStr "Output1: "
print(sanitize "http://wou.edu/my homepage/I love spaces.html")
putStrLn ""

--Problem 5
putStrLn "-Problem 5-"
putStrLn "Input: [1,2,3,4,5,6,7,8,9]"
putStr "Output: "
print(multListBy10 [1..9])
putStrLn ""

--Problem 6
putStrLn "-Problem 6-"
putStrLn "First Function"
putStrLn "Input: [1,2,3,4,5,6,7,8,9]"
putStr "Output: "
print(incrementList1 [1..9])
putStrLn "Second Function"
putStrLn "Input: \"Haskell is fun.\""
putStr "Output: "
print(incrementList2 "Haskell is fun.")
putStrLn ""

--Problem 7
putStrLn "-Problem 7-"
putStrLn "Input1: [12,15,87,968,54,23,5875,665,25,2]"
putStr "Output1: "
print(containsDivisibleBy42 [12,15,87,968,54,23,5875,665,25,2])
putStrLn "Input1: [987,85,53,336,2125,21,5151,84,646,64]"
putStr "Output1: "
print(containsDivisibleBy42 [987,85,53,336,2125,21,5151,84,646,64])
putStrLn ""

--Problem 8
putStrLn "-Problem 8-"
putStrLn "Input1: [1,3,5,7,9]"
putStr "Output1: "
print(powersOf10 [1,3,5,7,9])
putStrLn ""

--Problem 9
putStrLn "-Problem 9-"
putStrLn "Input: \"That is pretty neat         \""
putStr "Output: "
print(stringStripper "That is pretty neat         ")
putStrLn ""

--Problem 10
putStrLn "-Problem 10-"
putStrLn "Input: [2,2,4,6]"
putStr "Output: "
print(evenNumbers [2,2,4,6])
putStrLn ""

--Problem 11
putStrLn "-Problem 11-"
putStrLn "Input: [\"my chair\",\"my problem\"]"
putStr "Output: "
print(addNotToList ["my chair", "my problem"])
putStrLn ""

--Problem 12
putStrLn "-Problem 12-"
putStrLn "Input: [\"This\",\"is\",\"a\",\"sentence\"]"
putStr "Output: "
print(reverseListString ["This","is","a","sentence"])
putStrLn ""

--Problem 13
putStrLn "-Problem 13-"
putStrLn "Input: 8 9"
putStr "Output: "
print(addNumbers 8 9)
putStrLn ""

--Problem 14
putStrLn "-Problem 14-"
putStrLn "Input: 8"
putStr "Output: "
print(times4 8)
putStrLn ""

--Problem 15
putStrLn "-Problem 15-"
putStrLn "Input: [1,4,6,7,8,9]"
putStr "Output: "
print(secondElement [1,4,6,7,8,9])
putStrLn ""

--Problem 16
putStrLn "-Problem 16-"
putStrLn "Input: 17"
putStr "Output: "
print(roundSquare 17)
putStrLn ""

--Problem 17
putStrLn "-Problem 17-"
putStrLn "Input: \"This is a sentence written in the usual way\""
putStr "Output: "
print(splitSentence "This is a sentence written in the usual way")
putStrLn ""

--Problem 18
putStrLn "-Problem 18-"
putStrLn "Input: [(3,4),(5,16),(9.4,2)]"
putStr "Output: "
print(triangles [(3,4),(5,16),(9.4,2)])
putStrLn ""

--Part02_Problem 1
putStrLn "-Part02_Problem 1-"
putStrLn "In comments in source code"
putStrLn ""

--Part02_Problem 2
putStrLn "-Part02_Problem 2-"
putStrLn "Input: [9,8,7,6,5,4,3,2,1,0]"
putStr "Output: "
print(myLength [9,8,7,6,5,4,3,2,1,0])
putStrLn ""

--Part02_Problem 3.1
putStrLn "-Part02_Problem 3.1-"
putStrLn "Input: [1,2,3,4,5]"
putStr "Output: "
print(convertInttoStringLeft [1,2,3,4,5])
putStrLn ""

--Part02_Problem 3.2
putStrLn "-Part02_Problem 3.2-"
putStrLn "Input: [1,2,3,4,5]"
putStr "Output: "
print(convertInttoStringRight [1,2,3,4,5])
putStrLn ""

--Part02_Problem 4.1
putStrLn "-Part02_Problem 4.1"
putStrLn "Original Function: length (filter (<20) [1..100] "
putStr "Output: "
print("19")
putStrLn "Rewritten Function: length $ filter(<20) [1..100]"
putStr "Output: "
print("19")
putStrLn ""

--Part02_Problem 4.2
putStrLn "-Part02_Problem 4.2"
putStrLn "Original Function: take 10 (cycle (filter (>5) (map (*2) [1..10])))"
putStr "Output: "
print("[6,7,10,12,14,16,18,20,6,8]")
putStrLn "Rewritten Function: take 10 $ cycle $ filter (>5) $ map (*2) [1..10]"
putStr "Output: [6,7,10,12,14,16,18,20,6,8]"
print("Print the function output from function you rewrote here")
putStrLn ""
