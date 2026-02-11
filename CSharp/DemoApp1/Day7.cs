using System.Collections;

class ArraysPractice{
    public void Main()
    {
        int[] numbers={23,45,2,32,21};
        // foreach(int x in numbers)
        // {
        //     Console.WriteLine(x);
        // }

        int[,] matrix={{1,2,5},{3,4,8}};
        // Console.Write(matrix[1,1]);


        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i,j]+" ");
            }
            Console.WriteLine();
        }


        int[][] jagged=new int[2][];
        jagged[0]=new int[]{1,2};
        jagged[1]=new int[]{3,4,5};
        // Console.Write(jagged[1][2]);

        for(int i = 0; i < jagged.Length; i++)
        {
            for(int j = 0; j < jagged[i].GetLength(0); j++)
            {
                Console.Write(jagged[i][j]+" ");
            }
            Console.WriteLine();
        }

        Array.Clear(numbers,0,3);
        foreach(int x in numbers)
        {
            Console.Write(x+" ");
        }
        Console.WriteLine();
        int[] dest=new int[5];
        Array.Copy(numbers,dest,4);
        foreach(int x in dest)
        {
            Console.Write(x+" ");
        }    

        // int[] nums={1,2};

        //Array.Resize(nums,4);
        // Array.Resize(ref nums,1);
        // Console.WriteLine(nums.Length);

        int[] nums1={10,24,21,25};
        bool found=Array.Exists(nums1,x=> x>25);
        Console.WriteLine(found);
    }

}




class CollectionPrac
{
    public void Main()
    {
        // List<int> list=new List<int>();
        // list.Add(23);
        // list.Add(45);

        // Hashtable h1=new Hashtable();
        // h1.Add(1,"admin");
        // h1.Add(2,"user");



        // Stack stack=new Stack();
        // stack.Push(24);
        // stack.Push("2A");
        // Console.WriteLine(stack.Pop());
        // Console.WriteLine(stack.Pop());

        // Queue queue=new Queue();
        // queue.Enqueue(454);
        // queue.Enqueue("hello");
        // Console.WriteLine(queue.Dequeue());


        // Dictionary<int,string> dictionary=new Dictionary<int, string>();
        // dictionary.Add(1,"admin");
        // dictionary.Add(2,"User");
        // Console.WriteLine(dictionary[2]);


        // HashSet<int> set=new HashSet<int>();
        // set.Add(243);
        // set.Add(445);
        // set.Add(23);
        // foreach(int i in set)
        // {
        //     Console.Write(i+" ");
        // }
        // Console.WriteLine();


        // SortedList<string,string> sortList=new SortedList<string, string>();
        // sortList.Add("b","B");
        // sortList.Add("a","A");
        // //Console.WriteLine(sortList["b"]);
        // foreach(string i in sortList.Keys)
        // {
        //     Console.WriteLine(sortList[i]);
        // }
        // // Find the frequency of elements in an array using a Dictionary
        // int[] arr = {1, 2, 3, 2, 1, 4, 2};
        // Dictionary<int,int> dic=new Dictionary<int, int>();
        // foreach(int i in arr)
        // {
        //     if (dic.ContainsKey(i))
        //     {
        //         dic[i]++;
        //     }
        //     else
        //     {
        //         dic.Add(i,1);
        //     }
        // }
        // foreach(int i in dic.Keys)
        // {
        //     Console.WriteLine(i+":"+dic[i]);
        // }
        
        // Merge two sorted arrays into a single sorted array.
        // Max Time: 10 minutes
        // Explanation: Demonstrates merging and sorting techniques.
        int[] arr1 = {1, 3, 5};
        int[] arr2 = {2, 4, 6};


        int[] sortedArr=new int[arr1.Length+arr2.Length];
        int i=0;
        int j=0;
        int k=0;
        while (i < arr1.Length && j < arr2.Length)
        {
            if(arr1[i]<arr2[j])
            sortedArr[k++]=arr1[i++];
            else
            sortedArr[k++]=arr2[j++];
        }
        while(i<arr1.Length)
        sortedArr[k++]=arr1[i++];
        while(j<arr2.Length)
        sortedArr[k++]=arr2[j++];

        foreach(int n in sortedArr)
        Console.WriteLine(n);
    }
    
}