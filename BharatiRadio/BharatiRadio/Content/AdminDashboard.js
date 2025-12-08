document.addEventListener('DOMContentLoaded', () => {
    const navLinks = document.querySelectorAll('.nav-link');
    const contentSections = document.querySelectorAll('.content-section');
    const pageTitle = document.getElementById('page-title');

    // --- Navigation Handling ---
    navLinks.forEach(link => {
        link.addEventListener('click', (e) => {
            e.preventDefault();
            const targetId = link.getAttribute('data-target');

            // Update active link
            navLinks.forEach(navLink => navLink.classList.remove('active'));
            link.classList.add('active');

            // Update content section
            contentSections.forEach(section => {
                if (section.id === targetId) {
                    section.classList.add('active');
                } else {
                    section.classList.remove('active');
                }
            });

            // Update page title
            pageTitle.textContent = link.querySelector('span').textContent;
        });
    });

    // --- Modal Handling ---
    const bulletinModal = document.getElementById('bulletin-modal');
    const deleteModal = document.getElementById('delete-modal');
    const createBtn = document.getElementById('createNewBulletinBtn');
    const editBtns = document.querySelectorAll('.btn-edit');
    const deleteBtns = document.querySelectorAll('.btn-delete');
    const dismissBtns = document.querySelectorAll('[data-dismiss="modal"]');

    const openModal = (modal) => {
        if (modal) {
            modal.classList.add('active');
        }
    };

    const closeModal = (modal) => {
        if (modal) {
            modal.classList.remove('active');
        }
    };

    // Open "Create" modal
    if (createBtn) {
        createBtn.addEventListener('click', () => {
            document.getElementById('modal-title').textContent = 'Create New Bulletin';
            document.getElementById('bulletin-content').textContent = "";
            document.getElementById('bulletin-form').reset();
            document.getElementById('bulletin-form').action = "@Url.Action('NewBulletin', 'Admin')";
            openModal(bulletinModal);
        });
    }

    // Open "Edit" modal
    editBtns.forEach(btn => {
        btn.addEventListener('click', () => {
            document.getElementById('modal-title').textContent = 'Edit Bulletin';


            const id = btn.getAttribute('data-id');

            fetch(`/Admin/ViewBulletin?id=${encodeURIComponent(id)}`)
                .then(response => {
                    if (!response.ok) throw new Error('Network error');
                    return response.json();
                })
                .then(res => {
                    if (!res || res.success === false) {
                        alert(res?.message || 'Error loading suggestion');
                        return;
                    }

                    // Fill modal fields
                    document.getElementById('bulletin-id').value = res.id || '';
                    document.getElementById('bulletin-title').value = res.title || '';
                    document.getElementById('bulletin-status').value = res.status || '';
                    document.getElementById('bulletin-tag').value = res.tag || '';
                    document.getElementById('bulletin-content').textContent = res.content || '';
                    document.getElementById('bulletin-form').action = "@Url.Action('EditBulletin', 'Admin')";

                    // 👌 Works now because openModal is in scope!
                    openModal(bulletinModal);
                })
                .catch(err => {
                    console.error(err);
                    alert('Something went wrong');
                });

        });
    });

    // Open "Delete" modal
    deleteBtns.forEach(btn => {
        btn.addEventListener('click', () => {

            document.getElementById('delete-confirm-box').action = '/Admin/' + btn.getAttribute('data-ids');
            deleteModal.querySelector('#delete-item-val').value = btn.getAttribute('data-id');


            openModal(deleteModal);
        });
    });

    // Close modals
    dismissBtns.forEach(btn => {
        btn.addEventListener('click', () => {
            closeModal(btn.closest('.modal-overlay'));
        });
    });

    // Close modal on overlay click
    document.querySelectorAll('.modal-overlay').forEach(overlay => {
        overlay.addEventListener('click', (e) => {
            if (e.target === overlay) {
                closeModal(overlay);
            }
        });
    });

    // Handle form submission
    document.getElementById('bulletin-form').addEventListener('submit', (e) => {
        // In a real app, you would send this data to a server
        console.log('Form submitted');
        // You could add a success message here
    });

    // --- Mobile Menu Toggle ---
    const menuToggle = document.getElementById('menu-toggle');
    const sidebar = document.getElementById('sidebar');
    const mainContent = document.getElementById('main-content');

    if (menuToggle) {
        // This is a simple implementation for mobile.
        // A better one would toggle a class.
        console.warn('Mobile menu toggle logic not fully implemented in this static demo.');
        // Example of how it *would* work:
        // menuToggle.addEventListener('click', () => {
        //    sidebar.classList.toggle('is-open');
        //    mainContent.classList.toggle('sidebar-open');
        // });
    }

});

document.addEventListener('DOMContentLoaded', () => {

    const bulletinModal = document.getElementById('bulletin-modal');
    const deleteModal = document.getElementById('delete-modal');
    const dismissBtns = document.querySelectorAll('[data-dismiss="modal"]');

    const openModal = (modal) => {
        if (modal) modal.classList.add('active');
    };

    const closeModal = (modal) => {
        if (modal) modal.classList.remove('active');
    };

    // 🔹 Suggestion Modal Logic (add this here)
    const suggestionModal = document.getElementById('suggestion-modal');
    const viewSuggestionButtons = document.querySelectorAll('.btn-view-suggestion');

    viewSuggestionButtons.forEach(btn => {
        btn.addEventListener('click', () => {
            const id = btn.getAttribute('data-id');
            let row = btn.closest('tr');
            row.style.backgroundColor = "#E8E9EB";
            row.style.fontWeight = "normal";

            fetch(`/Admin/ViewSuggestion?id=${encodeURIComponent(id)}`)
                .then(response => {
                    if (!response.ok) throw new Error('Network error');
                    return response.json();
                })
                .then(res => {
                    if (!res || res.success === false) {
                        alert(res?.message || 'Error loading suggestion');
                        return;
                    }

                    // Fill modal fields
                    document.getElementById('sugg-sub').textContent = res.sub || '';
                    document.getElementById('sugg-name').textContent = res.name || '';
                    document.getElementById('sugg-email').textContent = res.email || '';
                    document.getElementById('sugg-contact').textContent = res.contact_no || '';
                    document.getElementById('sugg-loction').textContent = res.location || '';
                    document.getElementById('sugg-msg').textContent = res.msg || '';
                    document.getElementById('delete-item-val').value = res.id || '';
                    document.querySelector('.mark-btn').dataset.markId = res.id || '';
                    if (res.mark == "1") {
                        document.querySelector('.mark-btn').dataset.Bookmark = true;
                        document.querySelector('.mark-btn').innerHTML = '<i class="ph-fill ph-bookmark"></i>';
                    }
                    else {
                        document.querySelector('.mark-btn').dataset.dataBookmark = false;
                        document.querySelector('.mark-btn').innerHTML = '<i class="ph ph-bookmark"></i>';
                    }


                    // 👌 Works now because openModal is in scope!
                    openModal(suggestionModal);
                })
                .catch(err => {
                    console.error(err);
                    alert('Something went wrong');
                });
        });
    });
    document.querySelectorAll('.mark-btn').forEach(btn => {

        btn.addEventListener('click', () => {

            fetch('/Admin/Bookmark', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ id: parseInt(btn.dataset.markId) })
            })
                .then(res => res.json())
                .then(data => {

                    if (!data.success) return alert("Error bookmarking");

                    const iconFilled = '<i class="ph-fill ph-bookmark bookmark-green"></i>';
                    const iconOutline = '<i class="ph ph-bookmark"></i>';

                    const isBookmarked = btn.dataset.bookmark === "true";

                    btn.innerHTML = isBookmarked ? iconOutline : iconFilled;
                    btn.dataset.bookmark = isBookmarked ? "false" : "true";
                })
                .catch(err => console.error(err));

        });

    });

    // Close modal on Cancel/X click
    dismissBtns.forEach(btn => {
        btn.addEventListener('click', () => {
            closeModal(btn.closest('.modal-overlay'));
        });
    });

    // Click outside to close
    document.querySelectorAll('.modal-overlay').forEach(overlay => {
        overlay.addEventListener('click', (e) => {
            if (e.target === overlay) closeModal(overlay);
        });
    });

});

