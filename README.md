--- 

## 📦 README.md

```markdown
# 🎲 운빨 인생 시뮬레이터 (Life Gacha Simulator)

하루의 운명을 가볍게 점쳐보는 AI 기반 인생 시뮬레이터!

Semantic Kernel 기반 에이전트를 통해, 입력한 단어나 상황에 따라 당신의 "랜덤 하루"를 이야기 형식으로 생성합니다. 인생의 굴곡, 우연한 만남, 뜻밖의 행운을 경험해보세요. 오늘은 어떤 하루가 기다리고 있을까요?

---

## Features

- **AI 이야기 생성**: 키워드 기반으로 매번 다른 운세 이야기 생성 
- **인생 가챠 스타일 서사**: 희로애락이 섞인 단막극 같은 하루  
- **매번 다른 결과**: 높은 temperature 설정으로 랜덤한 인생 묘사  
- **한국어 지원**: 한국어로 자연스러운 이야기 제공  

---

## Workshop Origin

```
이 프로젝트는 semantic-kernel-workshop 워크숍을 수강하면서 얻은 아이디어를 바탕으로 만들어졌습니다.
워크숍을 통해 Semantic Kernel의 핵심 개념과 에이전트 구조를 익히고, 개인적으로 흥미 있던 "운세 기반 인생 시뮬레이션" 아이디어를 실제로 구현해보았습니다.

특히 다음과 같은 부분을 확장해 보았습니다:
 - YAML 기반 프롬프트 커스터마이징
 - ChatCompletionAgent + ChatHistory 기반 흐름 설계
 - 단순 응답형 에이전트를 재미 요소가 있는 스토리텔러로 전환

```

---

## 🛠 Tech Stack

- .NET 8+
- Microsoft Semantic Kernel
- Azure OpenAI or OpenAI API
- C#

---

## 🚀 Getting Started

### 1. Clone the Repository

### 2. Set Up Configuration

### 3. Build & Run the App

1. 워크샵 디렉토리에 있는지 다시 한 번 확인합니다.

    ```bash
    cd LifeGacha
    ```

2. 전체 프로젝트를 빌드합니다.

    ```bash
    dotnet restore && dotnet build
    ```


3. 깃허브 API 액세스 토큰을 콘솔 앱에 등록합니다.

    ```bash
    dotnet user-secrets --project ./Workshop.ConsoleApp/ set GitHub:Models:AccessToken {{GitHub Models Access Token}}
    ```
4. 애플리케이션을 실행합니다.

    ```bash
     dotnet run --project ./LifeGacha.ConsoleApp
    ```
---

## 📂 Project Structure

```
├── LifeGacha.ConsoleApp
│   ├── appsettings.json
│   ├── Documents
│   │   └── tips.txt
│   ├── LifieGacha.ConsoleApp.csproj
│   ├── Plugins
│   │   └── LifeGachaAgent
│   └── Program.cs
└── LifeGacha.sln
```

---

## expample

```
오늘 하루 운세를 뽑아볼까요? 아무 단어나 입력해주세요 (종료하려면 엔터):
User: 연어
Assistant: 1. 🐟 아침 운동 중 강에 빠진 당신, 연어처럼 힘차게 거슬러 올라감!  
2. 🍣 점심 회식에서 연어 초밥을 홀짝이다가 "회 뜨는 법" 자격증 제안받음!  
3. 🧑‍🎨 밤에는 연어 그림을 그리다, 실수로 붓 떨어뜨리며 인생 최고의 명작 탄생!  

✨ 오늘의 운세: 거슬러 올라가다 보면 꼭 황금빛 연어처럼 빛날 날이 올 겁니다!
```

---

## 🔮 TODO (기여 환영!)

- [ ] 카드 뽑기 UI 추가
- [ ] 캐릭터 기반 스토리모드 (ex. 귀여운 마법사가 운세를 말해줌)
- [ ] Telegram 또는 Discord 챗봇 연동
- [ ] Web UI 버전 (Blazor, React 등)

---

## 🤝 Contributing

개선 아이디어, 버그 수정, 기능 제안 모두 환영합니다. PR이나 Isuue로 참여해주세요.

---

## 📄 License

MIT License

---

## 💡 Author

- made by [@bennychoi]
- inspired by semantic-kernel-workshop [https://github.com/devkimchi/semantic-kernel-workshop]
```

---

