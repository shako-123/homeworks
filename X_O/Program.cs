// See https://aka.ms/new-console-template for more information

// Static Section


string[,] firstMtrx = new string[3, 3];
int k = 1;
int togle = 2;
string player = "Player 1 : X";
string xo = "X";
bool winChek = false;
int moveCount = 0; // სვლების მთვლელი დავამატე ისეთი ქეისის დასაჭერად როცა მოგებული არ გვყავს

Console.WriteLine("Player 1 : X");
Console.WriteLine("Player 2 : O");
Console.WriteLine("\t");


// Matrix Input
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        firstMtrx[i, j] = Convert.ToString(k);
        k++;
    }
}


// Loop Section

while (winChek == false)
{
    Console.WriteLine("\t");
    Console.WriteLine(player);

    // Print Matrixt 
    for (int i = 0; i < firstMtrx.GetLength(0); i++)
    {
        for (int j = 0; j < firstMtrx.GetLength(1); j++)
        {
            Console.Write(firstMtrx[i, j] + "\t");
        }

        Console.WriteLine();
    }


    Console.WriteLine("To Make a move enter number from matrix:");
    Console.WriteLine("\t");
    int intTemp = Convert.ToInt32(Console.ReadLine());
    Console.Write("You Entered X on psositon: ");
    Console.WriteLine(intTemp);


    // მომხმარებლის გადმოსახედიდან 1 რიცხვის შეყვანა კი ბევრად უფრო მოსახერხებელია, თუმცა ასეთი გართულება არ მომითხოვია დავალებაში.
    // ორი პარამეტრი რომ მიგეღო რომლებიც პირდაპირ ორ განზომილებიანი მასივის ინდექსებს დაემთხვევოდა (მაგ.: row = 1 და column = 2 პირდაპირ დაიმეპებოდა firstMtrx[1,2] თან)
    // როგორც აღწერაში ეწერა OK იქნებოდა.
    // ყოჩაღ რომ ესეთი შეძელი 💪
    for (int x = 0; x < 3; ++x)
    {
        for (int y = 0; y < 3; ++y)
        {
            if (firstMtrx[x, y].Equals(Convert.ToString(intTemp)))
            {
                Console.WriteLine("OK");
                firstMtrx[x, y] = xo;
                // აქ გავზარდოთ სვლების მთვლელი
                moveCount++;
            }
        }
    }

    
    // მოიგო თუ არა ვინმემ შეგვიძლია უფრო მარტივად შევამოწმოთ ციკლის დახმარებით. შენი გზაც სწორია, თუმცა უფრო მარტივადაც შეიძლება

    if (moveCount == 9) // სულ 9 სვლა შეიძლება გაკეთდეს და თუ გაკეთდა ესეიგი ვერავინ მოიგო
    {
        Console.WriteLine("Draw");
        break;
    }
    
    // სვეტებში და სტრიქონებში შევამოწმოთ გვიწერია თუ არა სადმე სამი ერთიდაიგივე სიმბოლო
    for (int i = 0; i < 3; i++)
    {
        if (firstMtrx[i, 0] == firstMtrx[i, 1] && firstMtrx[i, 1] == firstMtrx[i, 2] ||
            firstMtrx[0, i] == firstMtrx[1, i] && firstMtrx[1, i] == firstMtrx[2, i])
        {
            winChek = true;
        }
    }
    
    // შევამოწმოთ დიაგონალზე ხომ არ გვიწერია სამი ერთიდიაგივე სიმბოლო
    if ((firstMtrx[0, 0] == firstMtrx[1, 1] &&
         firstMtrx[1, 1] == firstMtrx[2, 2] ) ||
        (firstMtrx[0, 2] == firstMtrx[1, 1] &&
         firstMtrx[1, 1] == firstMtrx[2, 0]))
    {
        winChek = true;
    }

    // თუ მოვიგეთ გავჩერდეთ
    if (winChek)
    {
        Console.WriteLine(xo + " WON!");
        break;
    }
    
    // თუ ვერ მოვიგეთ ვაგრძელებთ და ვცვლით მოთამაშეს
    if (togle % 2 == 0)
    {
        xo = "O";
        player = "Player(O)  Please enter number: ";
    }
    else
    {
        xo = "X";
        player = "Player(X)  Please enter number: ";
    }

    togle++;


    Console.Write("Togle: ");
    Console.WriteLine(togle % 2);
    Console.WriteLine(winChek);
    Console.Clear();
}

;