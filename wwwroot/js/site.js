tailwind.config = {
              theme: {
                extend: {
                  colors: {
                    canvas: '#FAF8F5',
                    ink: '#111111',
                    muted: '#666666',
                    sun: '#F5BE24',
                    sunDark: '#D99B0F',
                    highlightBlue: 'rgba(219, 234, 254, 0.75)'
                  },
                  fontFamily: {
                    serif: ['"EB Garamond"', 'Georgia', 'serif'],
                    sans: ['"Inter"', 'sans-serif'],
                    mono: ['"JetBrains Mono"', 'monospace']
                  }
                }
              }
            }



            const body = document.body;
            const backdrop = document.getElementById('backdrop');

            // Trigger Elements
            const openAboutNav = document.getElementById('open-about-nav');
            const openAboutMobile = document.getElementById('open-about-mobile');
            const closeAboutBtn = document.getElementById('close-about-btn');
            const closeAboutLinks = document.querySelectorAll('.close-about-link');

            const openContactBtn = document.getElementById('open-contact-btn');
            const closeContactBtn = document.getElementById('close-contact-btn');

            // State management
            function openAboutDrawer() {
              closeContactDrawer();
              body.classList.add('drawer-left-open', 'overflow-hidden');
            }

            function closeAboutDrawer() {
              body.classList.remove('drawer-left-open');
              if (!body.classList.contains('drawer-right-open')) {
                body.classList.remove('overflow-hidden');
              }
            }

            function openContactDrawer() {
              closeAboutDrawer();
              body.classList.add('drawer-right-open', 'overflow-hidden');
            }

            function closeContactDrawer() {
              body.classList.remove('drawer-right-open');
              if (!body.classList.contains('drawer-left-open')) {
                body.classList.remove('overflow-hidden');
              }
            }

            function closeAllDrawers() {
              closeAboutDrawer();
              closeContactDrawer();
            }

            // Attach Event Listeners
            if (openAboutNav) openAboutNav.addEventListener('click', openAboutDrawer);
            if (openAboutMobile) openAboutMobile.addEventListener('click', openAboutDrawer);
            if (closeAboutBtn) closeAboutBtn.addEventListener('click', closeAboutDrawer);
            closeAboutLinks.forEach(link => link.addEventListener('click', closeAboutDrawer));

            if (openContactBtn) openContactBtn.addEventListener('click', openContactDrawer);
            if (closeContactBtn) closeContactBtn.addEventListener('click', closeContactDrawer);

            // Click on Backdrop closes active drawer
            if (backdrop) backdrop.addEventListener('click', closeAllDrawers);

            // Escape Key Dismissal
            window.addEventListener('keydown', (e) => {
              if (e.key === 'Escape') {
                closeAllDrawers();
              }
            });

            // Copy Email Feedback Action
            document.addEventListener('click', function (e) {
  const btn = e.target.closest('#copy-email-btn');
  if (!btn) return;

  const email = btn.dataset.email;
  const label = document.getElementById('copy-email-text');

  navigator.clipboard.writeText(email).then(function () {
    if (label) {
      const original = label.innerText;
      label.innerText = 'Copied ✓';
      setTimeout(function () { label.innerText = original; }, 2400);
    }
  }).catch(function () {
    window.location.href = 'mailto:' + email;
  });
});

            // Simulated Contact Form Submission Feedback (Razor / MVC Compatible)
           document.addEventListener('submit', async function (e) {
  const form = e.target.closest('#contact-form');
  if (!form) return;
  e.preventDefault();

  const feedback = document.getElementById('form-feedback');
  const submitBtn = document.getElementById('submit-btn');
  const originalBtn = submitBtn.innerHTML;

  function show(message, ok) {
    feedback.textContent = message;
    feedback.classList.remove('hidden');
    feedback.classList.toggle('text-amber-300', ok);
    feedback.classList.toggle('text-red-300', !ok);
  }

  submitBtn.disabled = true;
  submitBtn.innerHTML = '<span>' + form.dataset.msgProcessing + '</span>';
  feedback.classList.add('hidden');

  try {
    const response = await fetch(form.action, {
      method: 'POST',
      body: new FormData(form),
      headers: { 'X-Requested-With': 'XMLHttpRequest' }
    });

    if (!response.ok) {
      show(form.dataset.msgSecurity, false);
    } else {
      const result = await response.json();
      show(result.message, result.success);
      if (result.success) form.reset();
    }
  } catch (err) {
    show(form.dataset.msgConnection, false);
  } finally {
    submitBtn.disabled = false;
    submitBtn.innerHTML = originalBtn;
  }
});