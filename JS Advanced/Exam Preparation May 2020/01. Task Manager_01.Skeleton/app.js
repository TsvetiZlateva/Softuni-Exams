function solve() {
    const sections = document.querySelectorAll('section');
    const openDiv = sections[1].querySelectorAll('div')[1];
    const progressDiv = sections[2].querySelectorAll('div')[1];
    const finishedDiv = sections[3].querySelectorAll('div')[1];

    const inputTask = document.querySelector('#task');
    const inputDesc = document.querySelector('#description');
    const inputDate = document.querySelector('#date');

    const btnAdd = document.querySelector('#add');
    btnAdd.addEventListener('click', addTask);

    function addTask(e){
        e.preventDefault();
        
        //прочитаме съдържанието на формуляра и валидираме
        const taskName = inputTask.value;
        const taskDesc = inputDesc.value;
        const taskDate = inputDate.value;

        if(taskName.length > 0 && taskDesc.length > 0 && taskDate.length > 0){
            const startBtn = el('button', 'Start', {className: 'green'});
            const finishBtn = el('button', 'Finish', {className: 'orange'});
            const deleteBtn = el('button', 'Delete', {className: 'red'});

            const btnDiv = el('div',[
                startBtn,
                deleteBtn
            ], {className: 'flex'});

            const task = el('article', [
                el('h3', taskName),
                el('p', `Description: ${taskDesc}`),
                el('p', `Due Date: ${taskDate}`),
                btnDiv
            ]);

            //закачаме функционалността
            startBtn.addEventListener('click', () => {
                progressDiv.appendChild(task);
                startBtn.remove();
                btnDiv.appendChild(finishBtn);
            });

            finishBtn.addEventListener('click', () => {
                finishedDiv.appendChild(task);
                btnDiv.remove();
            });

            deleteBtn.addEventListener('click', () => {
                task.remove();
            });

            //добавяме елемента в DOM дървото
            openDiv.appendChild(task);

        }
    }


    function el(type, content, attributes){
        const result = document.createElement(type);

        if(attributes !== undefined){
            Object.assign(result, attributes);
        }

        if(Array.isArray(content)){
            content.forEach(append);
        }

        else{
            append(content);
        }

        function append(node){
            if(typeof node === 'string'){
                node = document.createTextNode(node);
            }
            result.appendChild(node);
        }

        return result;
    }
    



    //const divOpen = sections[1].querySelectorAll('div')[1];

    // function moveToOpen(e){
    //     e.preventDefault();
    //     //alert('open');
    //     // const divOpen = document.querySelector('.orange').parentNode.parentNode.parentNode.lastChild;
    //     const article = document.createElement('article');
    //     //alert(divOpen.parentElement.nodeName);
    //     divOpen.appendChild(article);
    //     const h3 = document.createElement('h3');
    //     h3.textContent = task.value;
    //     const p1 = document.createElement('p');
    //     p1.textContent = 'Description: ' + description.value;
    //     const p2 = document.createElement('p');
    //     p2.textContent = 'Due Date: ' + date.value;
    //     const div = document.createElement('div');
    //     article.appendChild(h3);
    //     article.appendChild(p1);
    //     article.appendChild(p2);
    //     article.appendChild(div);
    //     div.className = 'flex';
    //     const button1 = document.createElement('button');
    //     button1.className = 'green';
    //     const button2 = document.createElement('button');
    //     button2.className = 'red';
    //     div.appendChild(button1);
    //     div.appendChild(button2);

    // }

  


}