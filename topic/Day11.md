# Day-11 不是史書才能流傳

現在先回頭看看前面的做法與想法是一個什麼樣的思維

首先要了解一件事情

程式語言就像是日文，英文等，是一個溝通的語言

只是這次溝通的對象是機械，或是編譯器

如果我們為了跟外國人溝通，講了連我們自己都不瞭解的話

那當對方作出什麼樣的反應都可能造成誤會

同樣的我們寫了程式碼最後我們自己也看不懂，那編譯器也幫不上忙

所以，目標是寫出人類可讀的程式碼

而沒辦法到這麼完美所以就會剛剛好落在工程師可讀的程式碼 (這是我爸從小灌輸我的概念)

而只要工程師可讀的程式碼，就可以大幅度降低專案維護的複雜度

當然啦，這勢必還是少不了一些技術能力等等

這次先來說說為何必須要具有撰寫可讀的程式碼的能力

在Clean Code 中有一個原則叫做

**童子軍原則**

**離開營地前，讓營地比使用前更加乾淨**

這條原則會被提及代表著兩件事情
 - 我們過去在把程式交給別人前，都不會讓他以我們接手時更好的狀態出去
 - 我們總是接手到越來越糟糕的系統(包括自己給自己的坑)

而事實上我們雖然很少去懷疑，但現實中總是無法兌現的

`先求有，再求好` 這根本是場騙局 (註1)

而且講現實一點的，一個Project 往往Create 比Enhance 要來的貴很多

所以，如果不趁一開始的時候就把該寫好的一起寫清楚

那後面是沒有時間讓你補齊的　(你有足夠的肝嗎?)

而並不會有什麼是自己寫爽放著的程式

程式的目的，無論是完成需求，能力訓練，研究討論

都是人和人之間傳來傳去

所以沒有不會傳承的程式碼

只有因為難以傳承而只好頻頻重寫的程式碼

在還沒出社會之前，我一覺得工程師應該都有一套自己的Lib

出社會之後發現，好像不管怎麼作每次都還是得拆開來重做

我也有問過一些同事，似乎都認為根本很難達成

不過後來持續的嘗試，再加上新知的學習

才有辦法像現在這樣有一些心得

所以，總結一下心得
 - 不會沒有人會傳承自己寫下的東西，自己就是下一位承接者
 - 把程式當成寫給未來的自己，當作是給未來的自己的訊息
 - 只有不斷地使用自己寫過的東西，才會知道他難用在哪裡
 - 而連自己都覺得難用的東西，那別人更不會覺得好用

## 備註
---

 - 論證先求有再求好為何是騙局：近乎全部的狀況，先求有再求好表示功能會Release，Release 之後只會導致兩個結果，一個是因為一像進度完成後客戶或ＰＭ勢必未再要求新的功能，所以最後只能繼續先求有再求好，而只有三個機會是可以求好的
   - 系統快要爆炸了，但此時也無力回天只能看掉重練
   - 產品失敗公司快要倒了，你也許可以靠一己之力救專案，但也不是救這種地方
   - 你正在養老工作或是快離職了
   我不否是在嘲諷台灣的環境，更何況一個搖錢系統你說這次要更新只是為了求好，客戶只會跟你說現在很好，別來搗亂

## 命名小心得
---

 - 慣例 Prefix : 以開頭具名名稱或標記來對接下來的名稱做追述 (ex: 黑暗的 快速的 牛!?)
    - I : 介面
    - T : 泛行刑別參數
    - _ : 多用在內部變數
    - 所以你也可以將自己專案可以具有獨特性的文字當成prefix

 - 慣例 Suffix : 以結果字尾對前面的描述做追述 
    - s : 表示為負數
    - Async : 表示非同步需要等
    - Awaiter : 表示等待者
    - . ：前面名稱的某個東西 (ex: obj.Member)
    - 所以任何一個標記甚至是一個空白都是可以作為我們追加描述的利器