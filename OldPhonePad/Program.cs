using System;

class OldPhonePadText{
    static string[] key = {"&,)", "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"};

    static void OldPhonePad(string input) {
        string result = "";
        char current_btn = '\0';
        int space_cnt = 0;
        int key_index= 0;
        if(input == "" || input == null)
            return;

        foreach(char c in input){
        	if(current_btn == '\0')
            	current_btn = c;
            if (char.IsDigit(c)) { // this is for digit 1-10
                if((int)Char.GetNumericValue(c) > 0){  // this was used to neglect '0'' value
                    if(c == current_btn){
                        key_index++;
                        space_cnt = 0;
                        continue;
                    }
                }                    
            }
            
            if(key_index > 0){
                int key_len = key[(int)Char.GetNumericValue(current_btn) - 1].Length;
                while(key_index > key_len){ // this is for cycling states for btn values 
                    key_index -= key_len;
                }
                result += key[(int)Char.GetNumericValue(current_btn) -1 ][key_index -1];
                key_index = 0;
                if (char.IsDigit(c)){
                    if((int)Char.GetNumericValue(c) > 0){
                        current_btn = c;
                        key_index++;
                    }
                }
            }
            
            if(c == '*'){
            	if(result.Length > 0)
                    result = result.Remove(result.Length - 1);
                current_btn = '\0';
                key_index = 0;
                continue;
            }
            if (c == '#')
                break;
            
            // I check both 'space' and '0' because 'space' was used in example and '0' is for btn_zero
            if(c == ' ' || c == '0'){
                space_cnt++;
                current_btn = '\0';
                // this is for determining if user wants to add a space between chars
                if(space_cnt == 2){
                    result += " ";
                    space_cnt = 0;
                    continue;
                }
            }
        }
        Console.WriteLine(result);
    }
    static void Main(string[] args)
    {
        // OldPhonePad("33#"); // output: E
        // OldPhonePad("227*#"); // output: B
        // OldPhonePad("4433555 555666#"); // output: HELLO
        // OldPhonePad("8 88777444666*664#"); // output: TURING


        // additional test data
        // OldPhonePad("1#");
        // OldPhonePad("22#");
        // OldPhonePad("333#");
        // OldPhonePad("4444#");
        // OldPhonePad("5555 555#");
        // OldPhonePad("66666 666#");
        // OldPhonePad("7777777#");
        // OldPhonePad("88888 88#");
        // OldPhonePad("999 9999#");
        // OldPhonePad("2 3 4 5 6#");
        // OldPhonePad("1 2 3 4 5 6 7#");
        // OldPhonePad("444 4444 555 555#");
        // OldPhonePad("222 333 444 555#");
        // OldPhonePad("666 777 888#");
        // OldPhonePad("555 5*5 555#");
        // OldPhonePad("12345*6789#");
        // OldPhonePad("33333*44444#");
        // OldPhonePad("222222 333333 444444#");
        // OldPhonePad("8888 777777 6666 5555 4444#");
        // OldPhonePad("22 333 4444 55555 66666#");
        // OldPhonePad("**** 11#");
        // OldPhonePad("*2*22*22 22*#");
        // OldPhonePad("  *  44444 3* #");
        // OldPhonePad("22 22 22 ****#");
        // OldPhonePad("222 22 222 **#");
    }
}
