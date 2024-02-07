--problem 1
squareRoot x = sqrt x
-- passing in 818281336460929553769504384519009121840452831049 evaluates to 9.045890428592033e23.

--problem 2
asciiPrevious x = pred x
-- passing in 'A' evaluates to @.

--problem 3
verifyEven x = (x `mod` 2) == 0
-- passing 10 evaluates to True while 5 evaluates to False.

--problem 4
gaussianProduct x = product([x| x <-[1,3..x]])
-- passing 100 evaluates to a painfully big number...  2725392139750729502980713245400918633290796330545803413734328823443106201171875.

--problem 5
largestInList x = maximum(tail (init x))
-- Takes in a list, x, and then drops the end of it off with init. After that it ignores the head by grabbing the tail, and takes the maximum value in that list.

--problem 6
constructList = 1:5:84:12:3:[]
-- This takes no inputs, but creates a list with the list construction operator.

--problem 7
firstXEvens :: Int -> [Int]
firstXEvens x = [x | x <-[1..(x*2)], verifyEven x]
-- This takes in x as an input, and doubles it. Then it counts all of the evens between this x*2, and sends them back.

--problem 8
oddsDivisible3and7 :: Int -> [Int]
oddsDivisible3and7 x = [x | x <-[1..x], (x `mod` 2) == 1, (x `mod` 3) == 0, (x `mod` 7) == 0]
-- This takes in x as an input, makes a list from 1-x, and then checks if the numbers in the list are divisible by both 3 and 7. If they are, then it returns those numbers.

--problem 9
oddsDivisible9 :: Int -> [Int]
oddsDivisible9 x = [x | x <-[100..x], (x `mod` 2) == 1, (x `mod` 9) == 0]
-- This takes in x as an input, uses it as the upper bounds of the list starting at 100, and then returns what ever values are divisible by 9.

--problem 10
countNegs :: [Int] -> Int
countNegs x = length[x | x <-x, x < 0]
-- Takes a list as input, and counts the number of negative items inside of the list.

--problem 11
hexMaps :: [(Int,String)]
hexMaps = zip [0..15] ["0","1","2","3","4","5","6","7","8","9","A","B","C","D","E","F"]
-- This takes in nothing, but makes a hex mapping from 1 - 15. I have no clue how to get the hex to work in a Texas range and tried all kinds of things for quite a while with tons of googling.

--problem 12
makeList' :: Int -> [[Int]]
makeList' x
    | x < 1 = []
    | otherwise = [1..x] : makeList' (x-1)

makeList :: Int -> [[Int]]
makeList x = reverse $ makeList' x
-- This takes in a value for x, and then recursively calls itself to generate a scalling list of lists.

--problem 13
sanitize :: String -> String
sanitize x = [ y | z <- x , y <- if (z == ' ') then "%20" else [z] ]
-- This takes in a string and replaces the spaces with %20.

--problem 14
-- (*) :: Num a => a -> a -> a -- Will work with Float, Integer, Int, Double.
-- (++) :: [a] -> [a] -> [a] -- Will work with Int, Integer, Float, Double.
-- min :: Ord a => a -> a -> a -- Will work with Int, Integer, Float, Double, Char.
-- length :: Foldable t => t a -> Int -- Will work with Int, Integer, Float, Double, Char.
-- sqrt :: Floating a => a -> a -- Will work with Int, Integer, Float, Double.

--problem15
getSuit :: Int -> String
getSuit 0 = "Heart"
getSuit 1 = "Diamond"
getSuit 2 = "Spade"
getSuit 3 = "Club"
getSuit x = "ERROR!"
-- Takes in of x, and checks to see if it is bigger than 3 and if so, prints Error. If not, then it prints Heart for 0,
--  Diamond for 1, Spade for 2, and Club for 3.

--problem16
first :: (a, b, c) -> a
first (x, _, _) = x

second :: (a, b, c) -> b
second (_, y, _) = y

third :: (a, b, c) -> c
third (_, _, z) = z

dotProduct :: (Double,Double,Double) -> (Double,Double,Double) -> Double
dotProduct a b = first a * first b + second a * second b + third a * third b
-- Takes in two lists of doubles with 3 items each, and performs the dot product on them.

--problem17
reverseFirstThree :: [a] -> [a]
reverseFirstThree [] = []
reverseFirstThree [x] = [x]
reverseFirstThree [x,y] = [y,x]
reverseFirstThree [x,y,z] = [z,y,x]
reverseFirstThree [x,y,z,_] = [z,y,x]
-- This takes in a list, and will swap the first three or two values, and if it is 1 or has more will ignore it. Couldn't get the rest of the list to show up though.

--problem18
feelsLike :: Double -> String
feelsLike x
    | x <= -45.3 = "Frostbite Central!"
    | x <= 0 = "That's freakin cold man!"
    | x <= 45 = "Cool"
    | x <= 80 = "Not bad weather today."
    | x <= 90 = "Ok, it's getting a little hot."
    | x <= 110 = "You should go inside, it's nicer there."
    | x > 110 = "Why would you even think about going outside?"

--problem19
feelsLike2 :: Double -> (Double,String)
feelsLike2 x
    | y <= -45.3 = (y,"Frostbite Central!")
    | y <= 0 = (y,"That's freakin cold man!")
    | y <= 45 = (y,"Cool")
    | y <= 80 = (y, "Not bad weather today.")
    | y <= 90 = (y, "Ok, it's getting a little hot.")
    | y <= 110 = (y, "You should go inside, it's nicer there.")
    | y > 110 = (y, "Why would you even think about going outside?")
    where y = (x *(9/5)) + 32

--problem20
cylinder :: (RealFloat a) => a -> a -> a
cylinder r h = h * r^2 * pi

cylinderToVolume :: [(Double,Double)] -> [Double]
cylinderToVolume x = [y | (r, h) <-x, let y = (cylinder r h)]
-- This takes in a tuple of Doubles, and then calculates the volume based on their r and h values.
-- After it passes one group of them to the cylinder function, it then grabs the next and does it again.


main=do
--problem 1
putStrLn("")
putStrLn("-Problem 1-")
putStrLn("Input: 818281336460929553769504384519009121840452831049")
putStr("Output: ")
print(squareRoot 818281336460929553769504384519009121840452831049)
putStrLn("")

--Problem 2
putStrLn("-Problem 2-")
putStrLn("Input: 'A'")
putStr("Output: ")
print(asciiPrevious 'A')
putStrLn("")

--Problem 3
putStrLn("-Problem 3-")
putStrLn("Input1: 5")
putStr("Output1: ")
print(verifyEven 5)
putStrLn("Input2: 10")
putStr("Output2: ")
print(verifyEven 10)
putStrLn("Input3: 6541562")
putStr("Output3: ")
print(verifyEven 6541562)
putStrLn("")

--Problem 4
putStrLn("-Problem 4-")
putStrLn("Input: 100")
putStr("Output: ")
print(gaussianProduct 100)
putStrLn("")

--Problem 5
putStrLn("-Problem 5-")
putStrLn("Input: [99,23,4,2,67,82,49,-40]")
putStr("Output: ")
print(largestInList [99,23,4,2,67,82,49,-40])
putStrLn("")

--Problem 6
putStrLn("-Problem 6-")
putStr("Output: ")
print(constructList)
putStrLn("")

--Problem 7
putStrLn("-Problem 7-")
putStrLn("Input: 27")
putStr("Output: ")
print(firstXEvens 27)
putStrLn("")

--Problem 8
putStrLn("-Problem 8-")
putStrLn("Input: 200")
putStr("Output: ")
print(oddsDivisible3and7 200)
putStrLn("")

--Problem 9
putStrLn("-Problem 9-")
putStrLn("Input: 200")
putStr("Output: ")
print(oddsDivisible9 200)
putStrLn("")

--Problem 10
putStrLn("-Problem 10-")
putStrLn("Input: [(-4),6,7,8,(-14)]")
putStr("Output: ")
print(countNegs [(-4),6,7,8,(-14)])
putStrLn("")

--Problem 11
putStrLn("-Problem 11-")
putStr("Output: ")
print(hexMaps)
putStrLn("")

--Problem 12
putStrLn("-Problem 12-")
putStrLn("Input1: 7")
putStr("Output1: ")
print(makeList 7)
putStrLn("Input2: 0")
putStr("Output2: ")
print(makeList 0)
putStrLn("Input3: -1")
putStr("Output3: ")
print(makeList (-1))
putStrLn("")

--Problem 13
putStrLn("-Problem 13-")
putStrLn("Input: \"http://wou.edu/my homepage/I love spaces.html\"")
putStr("Output: ")
print(sanitize "http://wou.edu/my homepage/I love spaces.html")
putStrLn("")

--Problem 15
putStrLn("-Problem 15-")
putStrLn("Input1: 0")
putStr("Output1: ")
print(getSuit 0)
putStrLn("Input2: 1")
putStr("Output2: ")
print(getSuit 1)
putStrLn("Input3: 2")
putStr("Output3: ")
print(getSuit 2)
putStrLn("Input4: 3")
putStr("Output4: ")
print(getSuit 3)
putStrLn("Input5: 77")
putStr("Output5: ")
print(getSuit 77)
putStrLn("")

--Problem 16
putStrLn("-Problem 16-")
putStrLn("Input: (1,2,3.0) (4.0,5,6)")
putStr("Output: ")
print(dotProduct (1,2,3.0) (4.0,5,6))
putStrLn("")

--Problem 17
putStrLn("-Problem 17-")
putStrLn("Input1: [1]")
putStr("Output1: ")
print(reverseFirstThree [1])
putStrLn("Input2: [1,2]")
putStr("Output2: ")
print(reverseFirstThree [1,2])
putStrLn("Input3: [1,2,3]")
putStr("Output3: ")
print(reverseFirstThree [1,2,3])
putStrLn("Input4: [1,2,3,4]")
putStr("Output4: ")
print(reverseFirstThree [1,2,3,4])
putStrLn("")

--Problem 18
putStrLn("-Problem 18-")
putStrLn("Input1: -200")
putStr("Output1: ")
print(feelsLike (-200))
putStrLn("Input2: 200")
putStr("Output2: ")
print(feelsLike 200)
putStrLn("Input3: -45.3")
putStr("Output3: ")
print(feelsLike (-45.3))
putStrLn("Input4: 79")
putStr("Output4: ")
print(feelsLike 79)
putStrLn("")

--Problem 19
putStrLn("-Problem 19-")
putStrLn("Input1: -200")
putStr("Output1: ")
print(feelsLike2 (-200))
putStrLn("Input2: -0.1")
putStr("Output2: ")
print(feelsLike2 (-0.1))
putStrLn("Input3: -42.9444444444444444444444444445")
putStr("Output3: ")
print(feelsLike2 (-42.9444444444444444444444444445))
putStrLn("Input4: 100")
putStr("Output4: ")
print(feelsLike2 100)
putStrLn("")

--Problem 20
putStrLn("-Problem 20-")
putStrLn("Input: [(2,5.3),(4.2,9),(1,1),(100.394)]")
putStr("Output: ")
print(cylinderToVolume [(2,5.3),(4.2,9),(1,1),(100.3,94)])