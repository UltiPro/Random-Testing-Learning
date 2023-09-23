function sendHttpRequest(method, url, data) {
    return fetch(url, {
        method: method,
        body: JSON.stringify(data),
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(response => {
        if (response.status >= 200 && response.status < 300) {
            return response.json();
        } else {
            return response.json().then(errData => {
                console.log(errData);
                throw new Error('Something went wrong - server-side.');
            });
        }
    }).catch(error => {
        console.log(error);
        throw new Error('Something went wrong!');
    });
}

async function fetchPosts() {
    try {
        const responseData = await sendHttpRequest(
            'GET',
            'https://jsonplaceholder.typicode.com/posts'
        );
    } catch (error) {
        alert(error.message);
    }
}

async function createPost(title, content) {
    const userId = Math.random();
    const post = {
        title: title,
        body: content,
        userId: userId
    };
    sendHttpRequest('POST', 'https://jsonplaceholder.typicode.com/posts', post);
}

fetchButton.addEventListener('click', fetchPosts);

postList.addEventListener('click', event => {
    if (event.target.tagName === 'BUTTON') {
        const postId = event.target.closest('li').id;
        sendHttpRequest(
            'DELETE',
            `https://jsonplaceholder.typicode.com/posts/${postId}`
        );
    }
});