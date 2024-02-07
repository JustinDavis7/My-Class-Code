male(abraham).
male(herb).
male(clancy).
male(homer).
male(bart).

female(mona).
female(jackie).
female(marge).
female(patty).
female(selma).
female(lisa).
female(maggie).
female(ling).

parent(abraham, herb).
parent(abraham, homer).
parent(mona, herb).
parent(mona, homer).
parent(clancy, marge).
parent(clancy, patty).
parent(clancy, selma).
parent(jackie, marge).
parent(jackie, patty).
parent(jackie, selma).
parent(homer, bart).
parent(homer, lisa).
parent(homer, maggie).
parent(marge, bart).
parent(marge, lisa).
parent(marge, maggie).
parent(selma, ling).

father(abraham, herb).
father(abraham, homer).
father(clancy, marge).
father(clancy, patty).
father(clancy, selma).
father(homer, bart).
father(homer, lisa).
father(homer, maggie).

mother(mona, homer).
mother(jackie, marge).
mother(jackie, patty).
mother(jackie, selma).
mother(marge, bart).
mother(marge, lisa).
mother(marge, maggie).
mother(selma, ling).

grandfather(abraham, bart).
grandfather(abraham, lisa).
grandfather(abraham, maggie).
grandfather(clancy, bart).
grandfather(clancy, lisa).
grandfather(clancy, maggie).
grandfather(clancy, ling).

grandmother(mona, bart).
grandmother(mona, lisa).
grandmother(mona, maggie).
grandmother(jackie, ling).
grandmother(jackie, bart).
grandmother(jackie, lisa).
grandmother(jackie, maggie).

sister(marge, patty).
sister(marge, selma).
sister(patty, marge).
sister(patty, selma).
sister(selma, marge).
sister(selma, patty).
sister(lisa, bart).
sister(lisa, maggie).
sister(maggie, bart).
sister(maggie, lisa).

aunt(marge, ling).
aunt(patty, ling).
aunt(patty, maggie).
aunt(patty, lisa).
aunt(patty, bart).
aunt(selma, bart).
aunt(selma, lisa).
aunt(selma, maggie).
aunt(selma, ling).

/**
*Problem 3 -----------------------------------------------
*1. grandmother(X, bart).
*2. get_grandchildren(X, A). --- X is the persons name.
*3. get_aunts(X, A).
*4. get_grandparents(X, A).
*5. get_siblings(X, A). ---Currently there are no brothers, so I commented out the brother check but that would be in there without the . after sister() if they existed here.
*/

get_grandchildren(X, Y) :-
    parent(X, Z),
    parent(Z, Y).

get_aunts(X, Y) :-
    aunt(Y, X).
    
get_siblings(X, Y) :-
    sister(Y, X).
    /**;
    * brother(X, Y).*/  
    
get_grandparents(X, Y) :-
    parent(Z, X),
    parent(Y, Z).
    
/**
* Part Two --------------------
*/

house(C, A, P, D, S).

next_to(X, Y, List) :- is_right(X, Y, List). 
next_to(X, Y, List) :- is_right(Y, X, List).

is_right(L, R, [L | [R | _]]).
is_right(L, R, [_ | Rest]) :- is_right(L, R, Rest).

owns_owl(Street, Who) :-
    Street = [_House1, _House2, _House3, _House4, _House5], 
    member(house(red, osu_alum, _, _, _), Street),
    member(house(_, oit_alum, dog, _, _), Street),
    member(house(green, _, _, coffee, _), Street),
    member(house(_, uofo_alum, _, tea, _), Street),
    is_right(house(green,_,_,_,_), house(ivory,_,_,_,_), Street), 
    member(house(_, _, snails, _, cookies), Street),
    member(house(yellow, _, _, _, twinkies), Street),
    Street = [_, _, house(_, _, _, milk, _), _, _],
    Street = [house(_,psu_alum,_,_,_)|_],
    next_to(house(_, _, _, _, pie), house(_, _, fox, _, _), Street),
    next_to(house(_, _, _, _, twinkies), house(_, _, horse, _, _), Street),
    member(house(_, _, _, oj, icecream), Street),
    member(house(_, wou_alum, _, _, cheesecake), Street),
    next_to(house(_, psu_alum, _, _, _), house(blue, _, _, _, _), Street),
    member(house(_, Who, owl, _, _), Street).
    
