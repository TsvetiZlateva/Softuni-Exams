//Problem 2. Press House

function result(){
    class Article{
        constructor(title, content){
            this.title = title;
            this._content = content;
        }

        toString(){
            return `Title: ${this.title}` + '\n' + `Content: ${this._content}`;
        }
    }

    class ShortReports extends Article{
        constructor(title, content, originalResearch){
            if(content.length > 150){
                throw new Error("Short reports content should be less then 150 symbols.");
            }
            if(!originalResearch.author || !originalResearch.title){
                throw new Error("The original research should have author and title.");
            }
            super(title, content);
            this.originalResearches = originalResearch,
            this.comments = [];
        }
       
        addComment(comment){
            this.comments.push(comment);
            return "The comment is added.";
        }

        toString(){
            if(this.comments.length !=0){
                this.comments.unshift('\n' + "Comments:");
            }
            return `${super.toString()}` + '\n' + `Original Research: ${this.originalResearches.title} by ${this.originalResearches.author}`.trim() + '\n'.trim() + `${this.comments.join('\n')}`;
        }
    }

    class BookReview extends Article{
        constructor(title, content, book){
            super(title, content);
            this.book ={
                name: book.name,
                author: book.author
            }
            this.clients = [];
        }

        addClient(clientName, orderDescription){
            let client = {};
            if(this.clients.find((c => c.clientName == clientName) && (c => c.orderDescription == orderDescription))){
                throw new Error("This client has already ordered this review.");
            }
            else{
                this.clients.push(client = {clientName: clientName, orderDescription: orderDescription});
                return `${clientName} has ordered a review for ${this.book.name}`;
            }
        }

        toString(){
            let printOrders="";
            if(this.clients.length !=0){
                printOrders += "Orders:" + '\n';
            }
            for(let i = 0; i< this.clients.length; i++){
                printOrders += `${this.clients[i].clientName} - ${this.clients[i].orderDescription}` + '\n';
            }

            return `${super.toString()}` + '\n' + `Book: ${this.book.name}` + '\n'.trim() + `${printOrders}`.trim();
        }
    
    }


    return{
        Article,
        ShortReports,
        BookReview
    }
}

// let classes = result()
//             let book = new classes.BookReview('The Great Gatsby is so much more than a love story', 'The Great Gatsby is in many ways similar to Romeo and Juliet, yet I believe that it is so much more than just a love story. It is also a reflection on the hollowness of a life of leisure. ...', { name: 'The Great Gatsby', author: 'F Scott Fitzgerald' });
                        
//             output = book.toString();

//             expectedOutput = `Title: The Great Gatsby is so much more than a love story
// Content: The Great Gatsby is in many ways similar to Romeo and Juliet, yet I believe that it is so much more than just a love story. It is also a reflection on the hollowness of a life of leisure. ...
// Book: The Great Gatsby`;
// console.log(output);


