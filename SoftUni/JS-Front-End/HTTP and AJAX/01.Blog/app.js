function attachEvents() {
  const mainUrl = "http://localhost:3030/jsonstore/blog";
  const fetchPosts = "/posts";
  const fetchComments = "/comments";

  const loadPostsBtn = document.getElementById("btnLoadPosts");
  const viewPostsBtn = document.getElementById("btnViewPost");

  const optionsDropDown = document.getElementById("posts");
  const postTitlePlace = document.getElementById("post-title");
  const postComments = document.getElementById("post-comments");
  const postBodyParagraph = document.getElementById('post-body');

  let postsCollection = {};

  loadPostsBtn.addEventListener("click", loadPosts);
  viewPostsBtn.addEventListener("click", viewPost);

  async function loadPosts() {

    const fetchResult = await fetch(mainUrl + fetchPosts);
    postsCollection = await fetchResult.json();

    optionsDropDown.innerHTML = '';
    postBodyParagraph.innerHTML = '';

    for (const [postId, post] of Object.entries(postsCollection)) {
      let option = document.createElement("option");
      option.value = postId;
      option.textContent = post.title;

      optionsDropDown.appendChild(option);
    }
  }

  async function viewPost() {
    const fetchResult = await fetch(mainUrl + fetchComments);
    const comments = await fetchResult.json();

    postComments.innerHTML = '';
    postTitlePlace.textContent = postsCollection[optionsDropDown.value].title;
    postBodyParagraph.textContent = postsCollection[optionsDropDown.value].body;

    let commentsCollection = Object.values(comments).filter(
      c => c.postId === optionsDropDown.value
    );
    
    commentsCollection.forEach(p => {
        let newComment = document.createElement('li');
        newComment.id = p.id;
        newComment.textContent = p.text;

        postComments.appendChild(newComment);
    })
     
  }
}

attachEvents();
