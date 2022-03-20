from rubik_solver import utils
from datetime import datetime
import time

def PrintSolution(solution = ['R', 'U']):
    sSolution = ''
    for e in solution:
        sSolution += str(e) + ' '
    return sSolution

def EndingOfTurn(turn = ''):
    if len(turn) == 1:
        return ''
    return turn[1]

def ChangeTurn(yCount = 0, xCount = 0, turn = ''):
    if xCount == 1:
        if str(turn[0]) == 'U':
            turn = str('F') + EndingOfTurn(turn)
        elif str(turn[0]) == 'F':
            turn = str('D') + EndingOfTurn(turn)
        elif str(turn[0]) == 'D':
            turn = str('B') + EndingOfTurn(turn)
        elif str(turn[0]) == 'B':
            turn = str('U') + EndingOfTurn(turn)
    elif xCount == 2:
        if str(turn[0]) == 'F':
            turn = str('B') + EndingOfTurn(turn)
        elif str(turn[0]) == 'U':
            turn = str('D') + EndingOfTurn(turn)
        elif str(turn[0]) == 'B':
            turn = str('F') + EndingOfTurn(turn)
        elif str(turn[0]) == 'D':
            turn = str('U') + EndingOfTurn(turn)
    elif xCount == 3:
        if str(turn[0]) == 'U':
            turn = str('B') + EndingOfTurn(turn)
        elif str(turn[0]) == 'F':
            turn = str('U') + EndingOfTurn(turn)
        elif str(turn[0]) == 'D':
            turn = str('F') + EndingOfTurn(turn)
        elif str(turn[0]) == 'B':
            turn = str('D') + EndingOfTurn(turn)
    if yCount == 1:
        if str(turn[0]) == 'F':
            return str('R') + EndingOfTurn(turn)
        elif str(turn[0]) == 'R':
            return str('B') + EndingOfTurn(turn)
        elif str(turn[0]) == 'B':
            return str('L') + EndingOfTurn(turn)
        elif str(turn[0]) == 'L':
            return str('F') + EndingOfTurn(turn)
    elif yCount == 2:
        if str(turn[0]) == 'F':
            return str('B') + EndingOfTurn(turn)
        elif str(turn[0]) == 'R':
            return str('L') + EndingOfTurn(turn)
        elif str(turn[0]) == 'B':
            return str('F') + EndingOfTurn(turn)
        elif str(turn[0]) == 'L':
            return str('R') + EndingOfTurn(turn)
    elif yCount == 3:
        if str(turn[0]) == 'F':
            return str('L') + EndingOfTurn(turn)
        elif str(turn[0]) == 'R':
            return str('F') + EndingOfTurn(turn)
        elif str(turn[0]) == 'B':
            return str('R') + EndingOfTurn(turn)
        elif str(turn[0]) == 'L':
            return str('B') + EndingOfTurn(turn)
    return turn

def NormalizateSolution(solution = list()):
    lSolution = list()
    yCount = 0
    xCount = 0
    i = 0
    for i in range(len(solution)):
        if str(solution[i]) == "Y":
            yCount += 1
            if yCount == 4:
                yCount = 0
        elif str(solution[i]) == "Y'":
            yCount -= 1
            if yCount == -1:
                yCount = 3
        elif str(solution[i]) == "Y2":
            yCount += 2
            yCount = yCount % 4
        elif str(solution[i]) == "X":
            xCount += 1
            xCount = xCount % 4
        elif str(solution[i]) == "X'":
            xCount -= 1
            if xCount == -1:
                xCount = 3
        elif str(solution[i]) == "X2":
            xCount += 2
            xCount = xCount % 4
        elif str(solution[i]) == "M'":
            if yCount == 0:
                lSolution.append("R'")
                lSolution.append("L")
            elif yCount == 1:
                lSolution.append("B")
                lSolution.append("F'")
            elif yCount == 2:
                lSolution.append("R")
                lSolution.append("L'")
            elif yCount == 3:
                lSolution.append("B'")
                lSolution.append("F")
            xCount += 1
            xCount = xCount % 4
        elif str(solution[i]) == "M":
            if yCount == 2:
                lSolution.append("R'")
                lSolution.append("L")
            elif yCount == 3:
                lSolution.append("B")
                lSolution.append("F'")
            elif yCount == 0:
                lSolution.append("R")
                lSolution.append("L'")
            elif yCount == 1:
                lSolution.append("B'")
                lSolution.append("F")
            xCount -= 1
            if xCount == -1:
                xCount = 3
        elif str(solution[i]) == "M2":
            if yCount == 0:
                lSolution.append("R2")
                lSolution.append("L2")
            elif yCount == 1:
                lSolution.append("B2")
                lSolution.append("F2")
            elif yCount == 2:
                lSolution.append("R2")
                lSolution.append("L2")
            elif yCount == 3:
                lSolution.append("B2")
                lSolution.append("F2")
            xCount += 2
            xCount = xCount % 4
        else:
            lSolution.append(ChangeTurn(yCount, xCount, str(solution[i])))
    i = 0
    while i < len(lSolution) - 1:
        try:
            if str(lSolution[i])[0] == str(lSolution[i + 1])[0]:
                delta = 0
                if EndingOfTurn(str(lSolution[i])) == '':
                    delta = 1
                elif EndingOfTurn(str(lSolution[i])) == "2":
                    delta = 2
                elif EndingOfTurn(str(lSolution[i])) == "'":
                    delta = 3
                if EndingOfTurn(str(lSolution[i + 1])) == '':
                    delta = delta + 1
                elif EndingOfTurn(str(lSolution[i + 1])) == "2":
                    delta = delta + 2
                elif EndingOfTurn(str(lSolution[i + 1])) == "'":
                    delta = delta + 3
                if delta == 4 or delta == 0:
                    lSolution.pop(i)
                    lSolution.pop(i)
                elif delta == 5 or delta == 1:
                    lSolution[i] = str(lSolution[i])[0] + ""
                    lSolution.pop(i + 1)
                elif delta == 6 or delta == 2:
                    lSolution[i] = str(lSolution[i])[0] + "2"
                    lSolution.pop(i + 1)
                else:
                    lSolution[i] = str(lSolution[i])[0] + "'"
                    lSolution.pop(i + 1)
                i -= 2
            i += 1
        except:
            return lSolution
    return lSolution

def Avg(llist = list()):
    avg = 0.0
    for i in llist:
        avg += i
    return avg / len(llist)

def Min(llist = list()):
    min = 9999999999.0
    for i in llist:
        if i < min:
            min = i
    return min

def Max(llist = list()):
    max = 0.0
    for i in llist:
        if i > max:
            max = i
    return max

cubes = input('enter your cubes\n')
lcubes = cubes.split(" ")

countOfTurns = [0]
countOfTurns.pop()
times = [time.time()]
times.pop()
print("***************************** |Kociemba| *****************************")
for i in lcubes:
    start_time = time.time()
    solution = utils.solve(i, 'Kociemba')
    solvingtime = time.time() - start_time
    times.append(solvingtime)
    countOfTurns.append(len(solution))
    print(PrintSolution(solution))
for i in times:
    print(i)
for i in countOfTurns:
    print(i)
print("\nAVG time : " + str(Avg(times)) + "\nBest time : " + str(Min(times)) + "\nWorst time : " + str(Max(times)))
print("\nAVG turns : " + str(Avg(countOfTurns)) + "\nBest turns : " + str(Min(countOfTurns)) + "\nWorst turns : " + str(Max(countOfTurns)))

times.clear()
countOfTurns.clear()
print("***************************** |Beginner| *****************************")
for i in lcubes:
    start_time = time.time()
    solution = utils.solve(i, 'Beginner')
    solvingtime = time.time() - start_time
    solution = NormalizateSolution(solution)
    times.append(solvingtime)
    countOfTurns.append(len(solution))
    print(PrintSolution(solution))
for i in times:
    print(i)
for i in countOfTurns:
    print(i)
print("\nAVG time : " + str(Avg(times)) + "\nBest time : " + str(Min(times)) + "\nWorst time : " + str(Max(times)))
print("\nAVG turns : " + str(Avg(countOfTurns)) + "\nBest turns : " + str(Min(countOfTurns)) + "\nWorst turns : " + str(Max(countOfTurns)))

times.clear()
countOfTurns.clear()

print("***************************** |Fridrich| *****************************")
for i in lcubes:
    start_time = time.time()
    solution = utils.solve(i, 'CFOP')
    solvingtime = time.time() - start_time
    solution = NormalizateSolution(solution)
    times.append(solvingtime)
    countOfTurns.append(len(solution))
    print(PrintSolution(solution))
for i in times:
    print(i)
for i in countOfTurns:
    print(i)
print("\nAVG time : " + str(Avg(times)) + "\nBest time : " + str(Min(times)) + "\nWorst time : " + str(Max(times)))
print("\nAVG turns : " + str(Avg(countOfTurns)) + "\nBest turns : " + str(Min(countOfTurns)) + "\nWorst turns : " + str(Max(countOfTurns)))

times.clear()
countOfTurns.clear()
